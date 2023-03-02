using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPulse : MonoBehaviour
{
  public bool randomizeStart = true;
  public float minAmount;
  public float animationSpeed;

  private Light2D _light;
  private float _maxIntensity;
  private float _seedTime = 0;

  void Start()
  {
    _light = GetComponent<Light2D>();
    _maxIntensity = _light.intensity;

    if (randomizeStart)
      _seedTime = Random.Range(0f, 100f);
  }


  void Update()
  {
    float sin = Mathf.Abs(Mathf.Sin((Time.timeSinceLevelLoad + _seedTime) * animationSpeed));
    float outVal = Mathf.Lerp(minAmount, _maxIntensity, sin);
    _light.intensity = outVal;
  }
}
