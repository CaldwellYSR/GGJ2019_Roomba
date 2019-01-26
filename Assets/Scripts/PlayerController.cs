using UnityEngine;

public class PlayerController : MonoBehaviour
{

  [Range(0.05f, 0.5f)]
  public float playerSpeed;

  [Range(1f, 5f)]
  public float turnSpeed;

  public string throttleInput, turnInput;

    public GameObject Brush; 

    void FixedUpdate()
  {
    HandleMovement();
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
