using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static InputManager _THIS;

    // ENCAPSULATION
    public static InputManager THIS
    {
        get
        {
            return _THIS;
        }

    }
    private PlayerControls playercontrols;



    private void Awake()
    {
        if (_THIS != null && _THIS != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _THIS = this;

        }
        playercontrols = new PlayerControls();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playercontrols.Enable();
    }
    private void OnDisable()
    {
        playercontrols.Disable();
    }
    // ABSTRACTION
    public Vector2 GetPlayerMovement()
    {
        return playercontrols.Player.Movement.ReadValue<Vector2>();

    }
    public Vector2 GetMouseDelta()
    {
        return playercontrols.Player.Look.ReadValue<Vector2>();

    }

    public bool GetPlayerJump()
    {
        return playercontrols.Player.Jump.triggered;
    }

}
