using UnityEngine;
using UnityEngine.InputSystem;

public class VerticalSelectionInputMode : IInputMode
{
    private PlayerInput _playerInput;

    //public Vector2 JoystickMove_L => _playerInput.actions["Move"].ReadValue<Vector2>(); // Use Move action
    public Vector2 JoystickMove_L => Vector2.zero; // Disable Move input
    public Vector2 JoystickMove_R => Vector2.zero; // Disable Move input
    public bool JoystickClick_L => false; // Disabled in this mode
    public bool JoystickClick_R => false; // Disabled in this mode


    public bool L1 => false; // Disabled in this mode
    public bool R1 => false; // Disabled in this mode
    public bool L2 => false; // Disabled in this mode
    public bool R2 => false; // Disabled in this mode

    public bool Triangle  => false; // Disabled in this mode
    public bool Square  => false; // Disabled in this mode
    public bool Circle  => false; // Disabled in this mode
    public bool Cross  => false; // Disabled in this mode


    public bool Up => _playerInput.VERTICAL_SELECTION.UP.triggered; // Adjusted for correct action path
    public bool Down => _playerInput.VERTICAL_SELECTION.DOWN.triggered; // Adjusted for correct action path

    public VerticalSelectionInputMode(PlayerInput playerInput)
    {
        _playerInput = playerInput; // Initialize PlayerInput
    }

    public void UpdateInput() { }
}
