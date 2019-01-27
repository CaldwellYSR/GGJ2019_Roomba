using UnityEngine;

public class DustManager : MonoBehaviour
{

  [HideInInspector]
  public RenderTexture renderTexture;

  void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
    renderTexture = new RenderTexture(512, 249, 0);
  }
}
