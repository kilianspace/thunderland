using UnityEngine.InputSystem;

public class InputPayload{

  // Backing field for InputActions
  private InputModel _inputModel;

  // Public property to access InputActions
  public InputModel InputModel
  {
      get => _inputModel;
      set => _inputModel = value; // Set the value from external source
  }

  // Constructor to initialize InputActions
  public InputPayload(InputModel inputModel)
  {

      Log.Info("InputPayload / InputPayload Constructor", 1);
      _inputModel = inputModel;

      PlayerInput _playerInput = new PlayerInput();
      bool please = true;
      _playerInput.Enable();
  }

}
