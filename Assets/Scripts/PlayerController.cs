using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [Range(0.05f, 0.5f)]
  public float playerSpeed;

  [Range(1f, 5f)]
  public float turnSpeed;

  [Range(1f, 25f)]
  public float brushSize;

  public string throttleInput, turnInput;
  public Transform floor;

  public GameObject Brush; 
  public Color brushColor;
  private Vector2 floorSize;
  public Texture paintTexture;
  private RenderTexture renderTexture;
  private Material floorMat;

  private int homeWidth = 512, homeHeight = 249;

  void Start()
  {
    floorSize = new Vector2(
        (floor.GetComponent<BoxCollider2D>().size.x * floor.localScale.x),
        (floor.GetComponent<BoxCollider2D>().size.y * floor.localScale.y)
        );
    renderTexture = floor.GetComponent<DustManager>().renderTexture;
    floorMat = floor.GetComponent<SpriteRenderer>().material;
    floorMat.SetTexture("_MaskTex", renderTexture);
  }

  void FixedUpdate()
  {
    HandleMovement();
  }

  void LateUpdate()
  {
    PickupDust(); 
  }

  void HandleMovement()
  {
    var throttle = Input.GetAxis(throttleInput);
    transform.Translate(0, playerSpeed * throttle, 0);

    var turn = (throttle <= -0.05f) ? -1f : 1f;
    transform.Rotate(0, 0, turn * turnSpeed * -Input.GetAxis(turnInput));

    if (gameObject.activeSelf)
    {
      RotateBrush();
    }
  }

  void PickupDust()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, Mathf.Infinity, LayerMask.GetMask("Floor"));
    if (hit.collider != null)
    {
      var uv = new Vector2(
          homeWidth * (hit.point.x / floorSize.x),
          homeHeight * (hit.point.y / floorSize.y)
          );
      Paint(uv);
    }
  }

  void Paint(Vector2 uv)
  {
    float posX = uv.x;
    float posY = uv.y;

    Rect rect = new Rect(
        posX - paintTexture.width / brushSize,
        (renderTexture.height - posY) - paintTexture.height / brushSize,
        paintTexture.width / (brushSize * 0.5f),
        paintTexture.height / (brushSize * 0.5f)
        );

    RenderTexture.active = renderTexture;

    GL.PushMatrix();
    GL.LoadPixelMatrix(0, homeWidth, homeHeight, 0);

    Graphics.DrawTexture(
        rect,
        paintTexture,
        new Rect(0, 0, 1, 1), 0, 0, 0, 0, brushColor, null
        );

    renderTexture = RenderTexture.active;
    GL.PopMatrix();

    RenderTexture.active = null;
  }

  public void RotateBrush()
  {
    Brush.transform.Rotate(0, 0, 30);
  }
}
