public class Ladder : PlayerTriggerable
{
  protected override void OnPlayerEnter(Player player)
  {
    player.motor.canClimb = true;

  }

  protected override void OnPlayerExit(Player player)
  {
    player.motor.canClimb = false;
  }
}
