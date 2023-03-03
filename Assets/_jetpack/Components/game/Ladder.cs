public class Ladder : PlayerTriggerable
{

  //private int incrementer = 0;

  //private void Update()
  //{
  //incrementer++;
  //}

  protected override void OnPlayerEnter(Player player)
  {
    player.motor.canClimb = true;
  }


  protected override void OnPlayerExit(Player player)
  {
    player.motor.canClimb = false;
  }
}
