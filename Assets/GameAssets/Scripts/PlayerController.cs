using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Sensitivity settings")]
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float gamepadSensitivity = 200f;

    [Header("Vertical rotation limits")]
    [SerializeField] private float minVerticalAngle = -80f;
    [SerializeField] private float maxVerticalAngle = 80f;

    [Header("Target references")]
    [SerializeField] private Transform playerBody;

    private PlayerInputActions playerInputActions;

    private Vector2 currentLookInput = Vector2.zero;
    private float verticalPitch = 0.0f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Look.performed += OnLookPerformed;
        playerInputActions.Player.Look.canceled += OnLookCanceled;

        if(!playerBody)
            playerBody = transform.parent;
    }


    void Start()
    {
        DisableMouse();
    }

    void Update()
    {
        ApplyCameraRotation();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Look.performed -= OnLookPerformed;
        playerInputActions.Player.Look.performed -= OnLookCanceled;
    }

    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        currentLookInput = context.ReadValue<Vector2>();
        
        if(context.control.device is Mouse)
            currentLookInput *= mouseSensitivity;

        if(context.control.device is Gamepad)
            currentLookInput *= gamepadSensitivity * Time.deltaTime;
    }

    private void OnLookCanceled(InputAction.CallbackContext context)
    {
        currentLookInput = Vector2.zero;
    }

    private void ApplyCameraRotation()
    {
        verticalPitch -= currentLookInput.y;
        verticalPitch = Mathf.Clamp( verticalPitch, minVerticalAngle, maxVerticalAngle );
        transform.localRotation = Quaternion.Euler(verticalPitch, 0, 0);

        if(playerBody != null)
            playerBody.Rotate(Vector3.up * currentLookInput.x);
    }

    private void DisableMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
