using UnityEngine;

public class PlayerController : MonoBehaviour
{

  [Range(0.05f, 0.5f)]
  public float playerSpeed;

  [Range(1f, 5f)]
  public float turnSpeed;

  void FixedUpdate()
  {
    var throttle = Input.GetAxis("Vertical");
    transform.Translate(0, playerSpeed * throttle, 0);

    var turnAmount = Input.GetAxis("Horizontal");
    transform.Rotate(0, 0, turnSpeed * -turnAmount);
  }
}
