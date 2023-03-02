using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
  [SerializeField]
  [Range(0.01f, 1f)]
  private float _consumptionRate;
  [SerializeField]
  private float _thrust;

  public System.Action<float> onFuelUpdate;

  private float _fuel = 0;
  public float fuel
  {
    get { return _fuel; }
    set
    {
      _fuel = Mathf.Clamp01(value);
      onFuelUpdate?.Invoke(_fuel);
    }
  }

  private bool _active = false;
  public bool active
  {
    get { return _active; }
    set
    {
      _active = value;
      Player.Instance.motor.useGravity = !_active;
    }
  }

  private Rigidbody2D _rigidbody;

  void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    if (!active)
      return;

    fuel -= _consumptionRate * Time.fixedDeltaTime;
    Player.Instance.motor.AddVelocityToFrame(Vector2.up * _thrust);
    if (fuel == 0)
    {
      active = false;
    }
  }

  public void AddFuel(float amount)
  {
    fuel += amount;
  }
}
