using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
  //Load Scene
  public void Replay()
    {
        SceneManager.LoadScene("Game");
    }
  //Load Scene
  public void Back()
    {
        SceneManager.LoadScene("Start");
    }
    
}