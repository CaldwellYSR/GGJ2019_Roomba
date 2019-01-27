using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public float timeLeft = 90.0f;
  public Text timeLabel;

  void LateUpdate()
  {
    timeLeft -= Time.deltaTime;

    var minutes = Mathf.Floor(timeLeft / 60).ToString("0");
    var seconds = (timeLeft % 60).ToString("00");

    timeLabel.text = string.Format("{0}:{1}", minutes, seconds);

    if (timeLeft <= 0)
    {
      SceneManager.LoadScene("EndScene");
    }
  }
}
