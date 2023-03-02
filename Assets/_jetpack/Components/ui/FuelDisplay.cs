using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{
  [SerializeField]
  private Image _fuelBar;

  private void OnEnable()
  {
    UpdateFuelDisplay(Player.Instance.jetpack.fuel);
    Player.Instance.jetpack.onFuelUpdate += UpdateFuelDisplay;
  }

  private void OnDisable()
  {
    Player.Instance.jetpack.onFuelUpdate -= UpdateFuelDisplay;
  }

  private void UpdateFuelDisplay(float amount)
  {
    _fuelBar.fillAmount = amount;
  }
}
