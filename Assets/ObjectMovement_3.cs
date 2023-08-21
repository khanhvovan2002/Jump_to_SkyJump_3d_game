using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement_3 : MonoBehaviour
{   public float jumpForce = 5f;
    private bool canJump = false;
    public float rotationSpeed = 100f;
    void Update(){
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Check for spacebar input
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Check if player is not already a child of this object
            if(other.transform.parent == null || other.transform.parent != transform)
            {
                other.transform.SetParent(transform);
                Debug.Log(other.transform.position);
                canJump = true; // Player is on the object and can jump
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            canJump = false; // Player is no longer on the object and cannot jump
        }
    }
}

