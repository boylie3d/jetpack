using UnityEngine;

public class FloorAffector : MonoBehaviour
{
  [SerializeField]
  private float _moveDamping;
  public float moveDamping
  {
    get { return _moveDamping; }
  }
}
