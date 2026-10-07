using UnityEngine;
using UnityEngine.InputSystem;

public class GyroCameraController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Quaternion gyroAttitude = Quaternion.identity;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.GyroOrientation.performed += OnAttitudePerformed;
    }

    private void Update()
    {
        ApplyGyroRotation();
    }

    private void OnEnable()
    {
        if(AttitudeSensor.current != null){
            InputSystem.EnableDevice(AttitudeSensor.current);
        }
        else{
            Debug.LogWarning("Your device has no Gyroscope sensor");
        }

        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void OnDestroy()
    {
        playerInputActions.Player.GyroOrientation.performed -= OnAttitudePerformed;
    }

    private void OnAttitudePerformed(InputAction.CallbackContext context)
    {
        gyroAttitude = context.ReadValue<Quaternion>();
    }

    private void ApplyGyroRotation()
    {
        if(AttitudeSensor.current != null)
            return;
        
        Quaternion convertedAttitude = new Quaternion(gyroAttitude.x, gyroAttitude.y, -gyroAttitude.z, -gyroAttitude.w);
        Quaternion cameraRotation = Quaternion.Euler(90f, 0f, 0f) * convertedAttitude;

        transform.localRotation = cameraRotation;
    }
}
