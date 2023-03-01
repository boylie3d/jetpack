using Globatools.Core;

public class ScoreManager : Singleton<ScoreManager>
{
  public System.Action<int> onScoreUpdated;
  public int score { get; private set; } = 0;

  public void Add(int points)
  {
    score += points;
    onScoreUpdated?.Invoke(score);
  }
}
