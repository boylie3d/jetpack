using UnityEngine;

public class PlayerTriggerable : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    var player = collision.GetComponent<CharacterController2D>();
    if (player != null)
      OnPlayerEnter(player);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    var player = collision.GetComponent<CharacterController2D>();
    if (player != null)
      OnPlayerStay(player);
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    var player = collision.GetComponent<CharacterController2D>();
    if (player != null)
      OnPlayerExit(player);
  }
  protected virtual void OnPlayerEnter() { }
  protected virtual void OnPlayerEnter(CharacterController2D player) { }
  protected virtual void OnPlayerExit() { }
  protected virtual void OnPlayerExit(CharacterController2D player) { }
  protected virtual void OnPlayerStay() { }
  protected virtual void OnPlayerStay(CharacterController2D player) { }
}
