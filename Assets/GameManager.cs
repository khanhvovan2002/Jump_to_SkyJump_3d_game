using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton instance

    private int score = 0; // current score

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // set this as the singleton instance
        }
        else
        {
            Destroy(gameObject); // destroy duplicate instances
        }
    }

    public void AddScore(int value)
    {
        score += value; // add value to the score
        Debug.Log("Score: " + score); // log the updated score
    }
}