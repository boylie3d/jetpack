using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemySpinner : MonoBehaviour
{

  [SerializeField]
  private LayerMask groundLayer;
  [SerializeField]
  private float _rotateSpeed = 1f;
  [SerializeField]
  private float _moveSpeed = 1f;

  private SpriteRenderer _spriteRenderer;
  private Rigidbody2D _rigidbody;
  private Vector2 _moveDirection = new Vector2(1f, 0.8f);

  void Start()
  {
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    _spriteRenderer.transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
  }

  private void FixedUpdate()
  {
    //CheckSurroundings();
    _rigidbody.MovePosition((Vector2)transform.position + (_moveDirection * _moveSpeed * Time.fixedDeltaTime));
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    var player = collision.gameObject.GetComponent<Player>();
    if (player)
    {
      player.Kill();
      return;
    }

    var contactPoint = collision.GetContact(0).point;
    var dist = new Vector2(
      Mathf.Abs(transform.position.x - contactPoint.x),
      Mathf.Abs(transform.position.y - contactPoint.y)
      );

    // vertical hit
    if (dist.y > dist.x)
    {
      _moveDirection = new Vector2(_moveDirection.x, _moveDirection.y * -1);
    }
    // horizontal hit
    else if (dist.y < dist.x)
    {
      _moveDirection = new Vector2(_moveDirection.x * -1, _moveDirection.y);

    }
    else
    {
      _moveDirection = new Vector2(_moveDirection.x * -1, _moveDirection.y * -1);
    }
  }
}