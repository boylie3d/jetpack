public class Ladder : PlayerTriggerable
{
  protected override void OnPlayerEnter(CharacterController2D player)
  {
    player.canClimb = true;

  }
  protected override void OnPlayerExit(CharacterController2D player)
  {
    player.canClimb = false;
  }
}
