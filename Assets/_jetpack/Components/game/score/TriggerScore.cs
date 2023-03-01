public class TriggerScore : PlayerTriggerable
{
  public int scoreValue;
  protected override void OnPlayerEnter()
  {
    ScoreManager.Instance.Add(scoreValue);
  }
}
