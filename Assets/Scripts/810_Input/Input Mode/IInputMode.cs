using UnityEngine;

public interface IInputMode
{
  Vector2 JoystickMove_L { get; }
  Vector2 JoystickMove_R { get; }
  bool JoystickClick_L { get; }
  bool JoystickClick_R { get; }

  bool L1 { get; }
  bool R1 { get; }
  bool L2 { get; }
  bool R2 { get; }

  bool Triangle { get; }
  bool Square { get; }
  bool Circle { get; }
  bool Cross { get; }

  bool Up { get; }
  bool Down { get; }
  // bool Left { get; }
  // bool Right { get; }
  //
  // bool Confirm { get; }
  // bool Cancel { get; }
  // bool Start { get; }
  // bool Select { get; }

  void UpdateInput();
}
