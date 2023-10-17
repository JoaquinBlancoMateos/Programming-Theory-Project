using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    public GameObject interaction;
    public GameObject originInteraction;
    public float rayLength;


    // Start is called before the first frame update
    Vector2 movement;
    Vector3 move ;
    private void Start()
    {

        controller = gameObject.GetComponent<CharacterController>();
        inputManager = InputManager.THIS;
        cameraTransform = Camera.main.transform;

    }



    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        movement = inputManager.GetPlayerMovement();
        move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        transform.rotation =cameraTransform.rotation;
     /*   if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
     */
        // Changes the height position of the player..
        if (inputManager.GetPlayerJump() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        RaycastGround();
        InteraccionObjectMove();


    }

    // ABSTRACTION
    public void RaycastGround()
    {
        
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        RaycastHit hit;

       

        if (Physics.Raycast(ray, out hit, rayLength))
        {
           
            if (hit.collider.CompareTag("Toaster") && inputManager.GetPlayerInteracion())
            {

                interaction =hit.collider.gameObject;
                
                interaction.transform.position = originInteraction.transform.position;



            }
            Debug.Log("El raycast de la camara detecta: " + hit.collider.gameObject.name);
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

        }
        else
        {
            Debug.Log("El raycast de la camara no detecta nada");
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.green);

        }

    }

    void InteraccionObjectMove()
    {
        if (interaction != null)
        {
            interaction.transform.position = originInteraction.transform.position;
           // interaction.transform.rotation = originInteraction.transform.rotation;

        }

    }



}
