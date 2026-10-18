using UnityEngine;
using UnityEngine.InputSystem;

public class TestKeyController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.TestPressKey.performed += OnTestKeyPerformed;
    }

     private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    private void OnDestroy()
    {
        playerInputActions.Player.GyroOrientation.performed -= OnTestKeyPerformed;
    }

    public void OnTestKeyPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Test Key 'A' Pressed");
    }
}
