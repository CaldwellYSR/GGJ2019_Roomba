using UnityEngine;

public class PlayerController : MonoBehaviour
{

  [Range(0.05f, 0.5f)]
  public float playerSpeed;

  [Range(1f, 5f)]
  public float turnSpeed;

  public string throttleInput, turnInput;
  public Transform floor;

  private Vector2 floorSize;

  void Start()
  {
    floorSize = new Vector2(
      (floor.GetComponent<BoxCollider2D>().size.x * floor.localScale.x),
      (floor.GetComponent<BoxCollider2D>().size.y * floor.localScale.y)
    );
  }

    public GameObject Brush; 

    void FixedUpdate()
  {
    HandleMovement();
    PickupDust();
  }

  void PickupDust()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, Mathf.Infinity, LayerMask.GetMask("Floor"));
    if (hit.collider != null)
    {
      var uv = new Vector2(
        1024f * (hit.point.x / floorSize.x),
        1024f * (hit.point.y / floorSize.y)
      );
    }
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

    public void RotateBrush()
    {
        Brush.transform.Rotate(0, 0, 30);
    }
}
