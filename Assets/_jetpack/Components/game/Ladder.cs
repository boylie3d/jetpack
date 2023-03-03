using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ladder : PlayerTriggerable
{
  [Range(1, 16)]
  [SerializeField]
  private int _tileCount = 1;
  private SpriteRenderer _renderer;
  private BoxCollider2D _collider;

  private void OnValidate()
  {
    if (!Application.isPlaying)
      Generate();
  }

  private void Generate()
  {
    print("running");
    if (!_renderer)
      _renderer = transform.GetComponentInChildren<SpriteRenderer>();

    _renderer.size = new Vector2(_renderer.size.x, _tileCount);
    _renderer.transform.localPosition = Vector3.up * _tileCount / 2;

    if (!_collider)
      _collider = GetComponent<BoxCollider2D>();

    _collider.size = new Vector2(_collider.size.x, _tileCount);
    _collider.offset = Vector2.up * _tileCount / 2;
  }

  protected override void OnPlayerEnter(Player player)
  {
    player.motor.canClimb = true;
  }

  protected override void OnPlayerExit(Player player)
  {
    player.motor.canClimb = false;
  }
}
