using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject MyPlayer;
    private bool isColliding = false;
    private Vector3 playerOffset;

    private void Update()
    {
        if (isColliding)
        {
            // Handle collision logic here
            Debug.Log("Camera is colliding with an object");
            
            // Update the player's position relative to the moving obstacle
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            isColliding = true;

            // Set player's parent to moving obstacle and store the initial offset
            MyPlayer.transform.SetParent(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            isColliding = false;

            // Set player's parent to null and reset the offset
            MyPlayer.transform.SetParent(null);
        }
    }
}
