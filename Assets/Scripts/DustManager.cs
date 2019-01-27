using UnityEngine;

public class DustManager : MonoBehaviour
{

  [HideInInspector]
  public RenderTexture renderTexture;

  void Awake()
  {
    renderTexture = new RenderTexture(1024, 1024, 0);
  }
}
