using Globatools.Core;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Jetpack), typeof(CharacterMotor))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : Singleton<Player>
{
  public Jetpack jetpack { get; private set; }
  public CharacterMotor motor { get; private set; }
  private Rigidbody2D _rigidbody;
  private PlayerAction _input;

  void Awake()
  {
    base.Awake();

    _rigidbody = GetComponent<Rigidbody2D>();
    jetpack = GetComponent<Jetpack>();
    motor = gameObject.GetComponent<CharacterMotor>();

    _input = new PlayerAction();
    SetMovementEnabled(true);

    Level.Instance.onComplete += () => SetMovementEnabled(false);
  }

  private void OnEnable()
  {
    _input.FindAction("Jump").started += HandleJump;
    _input.FindAction("Jump").canceled += HandleJump;
  }

  private void OnDisable()
  {
    _input.FindAction("Jump").started -= HandleJump;
    _input.FindAction("Jump").canceled -= HandleJump;
  }

  private void HandleJump(InputAction.CallbackContext ctx)
  {
    if (ctx.phase == InputActionPhase.Started)
    {
      if (jetpack.fuel > 0)
      {
        jetpack.active = true;
      }
      else
      {
        motor.isJumping = true;
      }
    }
    else
    {
      jetpack.active = false;
      motor.isJumping = false;
    }
  }

  public void SetMovementEnabled(bool enabled)
  {
    if (enabled) _input.Enable();
    else _input.Disable();
  }

  private void Update()
  {
    Vector2 movement = _input.FindAction("Movement").ReadValue<Vector2>();
    motor.Move(Vector2.right * movement.x);
    motor.Climb(Vector2.up * movement.y);
  }
}
