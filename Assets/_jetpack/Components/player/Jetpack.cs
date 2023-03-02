using UnityEngine;

public class Jetpack : MonoBehaviour
{
  public float fuel { get; private set; } = 0;
  public bool active { get; set; }

  public System.Action<float> onFuelUpdate;

  void Start()
  {

  }

  void Update()
  {

  }

  public void AddFuel(float amount)
  {
    fuel = Mathf.Clamp((fuel + amount), 0, 1);
    onFuelUpdate?.Invoke(fuel);
  }
}
