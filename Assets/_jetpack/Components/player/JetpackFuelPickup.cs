public class JetpackFuelPickup : PlayerTriggerable
{
  public enum FuelPickupType { HALF, FULL }
  public FuelPickupType pickupType;

  private const float halfFuel = 0.5f, fullFuel = 1f;

  protected override void OnPlayerEnter()
  {
    Player.Instance.jetpack.AddFuel(pickupType == FuelPickupType.HALF ? halfFuel : fullFuel);
  }
}
