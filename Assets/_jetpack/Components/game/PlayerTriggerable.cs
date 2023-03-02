using UnityEngine;

public class PlayerTriggerable : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    var player = collision.GetComponent<Player>();
    if (player != null)
    {
      OnPlayerEnter();
      OnPlayerEnter(player);
    }
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    var player = collision.GetComponent<Player>();
    if (player != null)
    {
      OnPlayerStay();
      OnPlayerStay(player);
    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    var player = collision.GetComponent<Player>();
    if (player != null)
    {
      OnPlayerExit();
      OnPlayerExit(player);
    }
  }
  protected virtual void OnPlayerEnter() { }
  protected virtual void OnPlayerEnter(Player player) { }
  protected virtual void OnPlayerExit() { }
  protected virtual void OnPlayerExit(Player player) { }
  protected virtual void OnPlayerStay() { }
  protected virtual void OnPlayerStay(Player player) { }
}
