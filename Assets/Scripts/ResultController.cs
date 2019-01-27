using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
  public Text WinnerLabel, RedScoreLabel, BlueScoreLabel;

  private Color removeColor = new Color(0f, 0f, 0f, 0f);

  void Start()
  {
    var floor = GameObject.Find("Floor");
    var rtex = floor.GetComponent<DustManager>().renderTexture;
    var spriteRenderer = GetComponent<SpriteRenderer>();

    var tex = new Texture2D(rtex.width, rtex.height);

    RenderTexture.active = rtex;

    tex.ReadPixels(new Rect(0, 0, rtex.width, rtex.height), 0, 0);
    tex.Apply();

    var totalDust = tex.GetPixels();
    
    var redScore = totalDust.Where(color => color == Color.red).ToArray().Count() / (float)totalDust.Count() * 100;
    var blueScore = totalDust.Where(color => color == Color.white).ToArray().Count() / (float)totalDust.Count() * 100;

    redScore = Mathf.Round(redScore);
    blueScore = Mathf.Round(blueScore);

    var winner = (redScore > blueScore) ? "Red" : "Blue";

    WinnerLabel.text = winner + " Roomba Wins!!!";
    RedScoreLabel.text = "Red: " + redScore + "%";
    BlueScoreLabel.text = "Blue: " + blueScore + "%";

  }
}
