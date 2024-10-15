using UnityEngine.InputSystem;

public class InputPayload{

  private InputActions inputActions;
  public InputActions InputActions{ get; set; }

  public InputPayload(InputActions _input)
 {
     inputActions = _input;
 }

}
