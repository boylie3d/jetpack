using Globatools.Core;
using UnityEngine;

[RequireComponent(typeof(Jetpack))]
public class Player : Singleton<Player>
{
  //[SerializeField]
  //private Jetpack _jetpack;
  //public Jetpack jetpack { get { return _jetpack; } }
  public Jetpack jetpack { get; private set; }

  void Awake()
  {
    jetpack = GetComponent<Jetpack>();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
