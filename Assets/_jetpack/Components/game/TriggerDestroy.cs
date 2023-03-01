public class TriggerDestroy : PlayerTriggerable
{
  protected override void OnPlayerEnter()
  {
    Destroy(gameObject);
  }
}
