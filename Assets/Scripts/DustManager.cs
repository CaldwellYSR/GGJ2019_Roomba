using UnityEngine;

public class DustManager : MonoBehaviour
{

  [HideInInspector]
  public RenderTexture renderTexture;

  void Awake()
  {
    renderTexture = new RenderTexture(2048, 995, 0);
  }
}
