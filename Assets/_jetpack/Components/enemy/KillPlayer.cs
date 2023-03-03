public class KillPlayer : PlayerTriggerable
{
  protected override void OnPlayerEnter(Player player)
  {
    player.Kill();
  }

}
