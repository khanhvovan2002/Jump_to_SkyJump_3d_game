using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
{
    if(other.gameObject.CompareTag("Player"))
        {
                SceneManager.LoadScene("menu");
                 Cursor.lockState = CursorLockMode.None;
                    Coin.coinCount = 0;
        }
}
}

