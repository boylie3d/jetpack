using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
  public TextMeshProUGUI scoreLabel;

  private void OnEnable()
  {
    if (!ScoreManager.Instance)
    {
      this.enabled = false;
      return;
    }


    ScoreManager.Instance.onScoreUpdated += SetScore;

    SetScore(ScoreManager.Instance.score);
  }

  private void SetScore(int score)
  {
    scoreLabel.text = score.ToString("000000");
  }

  private void OnDisable()
  {
    ScoreManager.Instance.onScoreUpdated -= SetScore;
  }
}
