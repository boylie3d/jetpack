using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelEndDoor : PlayerTriggerable
{
  [SerializeField]
  private SpriteRenderer _closed, _open;
  private BoxCollider2D _coll;

  void Start()
  {
    _coll = GetComponent<BoxCollider2D>();
    _coll.enabled = false;
    _closed.enabled = true;
    _open.enabled = false;

    Level.Instance.onLevelComplete += () =>
    {
      _closed.enabled = false;
      _open.enabled = true;
      _coll.enabled = true;
    };
  }

  protected override void OnPlayerEnter()
  {
    print("I WIN'D!");
    Level.Instance.Complete();
  }
}
