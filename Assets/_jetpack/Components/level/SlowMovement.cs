using UnityEngine;

public class SlowMovement : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
  {
    print("called");
    var player = collision.gameObject.GetComponent<Player>();
    if (player == null) return;

    print("player is all up on my shit");
  }
}
