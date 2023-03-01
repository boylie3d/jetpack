public class Ladder : PlayerTriggerable
{
  protected override void OnPlayerEnter(CharacterController2D player)
  {
    print("player at ladder");

  }

  protected override void OnPlayerExit(CharacterController2D player)
  {
    print("player left ladder");
  }
}
