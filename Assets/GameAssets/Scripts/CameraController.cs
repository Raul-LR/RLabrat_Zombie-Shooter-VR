using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float minVerticalAngle = -80f;
    [SerializeField] private float maxVerticalAngle = 80f;
    [SerializeField] private Transform playerBody;
    private float verticalPitch = 0.0f;

    private void Awake()
    {
        if(!playerBody)
        {
            playerBody = transform.parent;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    private void Update()
    {
        ReadAndApplyLookInput();
    }

    // Method that reads look delta values from active input device and applies rotation
    private void ReadAndApplyLookInput()
    {
        Vector2 lookInput = Vector2.zero;

        // Read the input from the mouse
        Mouse mouse = Mouse.current;
        if(mouse != null)
        {
            Vector2 mouseDelta = mouse.delta.ReadValue();
            lookInput += mouseDelta;
        }

        // (Not Implemented yet) - Read the input from the game controller
        Gamepad gamepad = Gamepad.current;
        if(gamepad != null)
        {
            Vector2 gamePadDelta = gamepad.rightStick.ReadValue();
            lookInput += gamePadDelta;    
        }

        verticalPitch -= lookInput.y;
        verticalPitch = Mathf.Clamp( verticalPitch, minVerticalAngle, maxVerticalAngle );

        transform.localRotation = Quaternion.Euler( verticalPitch, 0.0f, 0.0f );

        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * lookInput.x);
        }
    }
}
