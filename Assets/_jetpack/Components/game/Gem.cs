using UnityEngine;

public class Gem : PlayerTriggerable
{
  public GameObject uncollected, collected;
  private Collider2D _coll;

  void Start()
  {
    _coll = GetComponent<Collider2D>();

    collected.SetActive(false);
    uncollected.SetActive(true);
  }

  protected override void OnPlayerEnter()
  {
    collected.SetActive(true);
    uncollected.SetActive(false);
    _coll.enabled = false;

    Level.Instance.CollectGem(this);
  }
}
