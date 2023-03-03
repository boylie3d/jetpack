using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
  [SerializeField]
  private SpriteRenderer _sprite;

  private bool _facingRight = true;

  void Start()
  {

  }

  void Update()
  {
    CalculateDirection();
    if (_facingRight)
      _sprite.transform.localScale = new Vector2(1, 1);
    else
      _sprite.transform.localScale = new Vector2(-1, 1);
  }

  private Vector2 _lastFrame;
  private void CalculateDirection()
  {
    var thisFrame = (Vector2)transform.position;
    var delta = thisFrame - _lastFrame;


    if (delta.x > 0)
    {
      _facingRight = true;
    }
    else if (delta.x < 0)
    {
      _facingRight = false;
    }
    _lastFrame = thisFrame;
  }
}
