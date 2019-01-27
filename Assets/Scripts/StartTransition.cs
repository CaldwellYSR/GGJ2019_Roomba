using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTransition : MonoBehaviour
{

    public void OpenStartScene()
    {
       SceneManager.LoadScene("SampleScene");
    }
}
