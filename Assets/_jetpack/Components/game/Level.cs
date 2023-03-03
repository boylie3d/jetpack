using Globatools.Core;
using System;
using System.Collections.Generic;

public class Level : Singleton<Level>
{
  private List<Gem> _gems;

  void Start()
  {
    _gems = new List<Gem>(FindObjectsOfType<Gem>());
  }

  public Action onLevelComplete;

  public void CollectGem(Gem gem)
  {
    _gems.Remove(gem);

    if (_gems.Count == 0)
      onLevelComplete?.Invoke();
  }

  public Action onComplete;
  public void Complete()
  {
    onComplete?.Invoke();
  }
}
