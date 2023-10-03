
using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager inputManager;
    private Vector3 startRotation;
    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]
    private float clampAngle = 80f;

    protected override void Awake()
    {  
       
        inputManager = InputManager.THIS;
        base.Awake();
      if (startRotation == null)
        {
            startRotation = transform.localRotation.eulerAngles;
        }
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = inputManager.GetMouseDelta();
                startRotation.x += deltaInput.x *verticalSpeed* Time.deltaTime;
                startRotation.y += deltaInput.y *horizontalSpeed *Time.deltaTime;
                startRotation.y = Mathf.Clamp(startRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startRotation.y,startRotation.x,0f);
            }

        }
    }



}
