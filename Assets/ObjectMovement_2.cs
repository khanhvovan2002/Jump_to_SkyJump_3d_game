using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement_2 : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float movementDistance = 2f;
    private Vector3 startPosition;
    public float jumpForce = 5f;
    private bool canJump = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate new position
        float newY = startPosition.y + Mathf.Sin(Time.time * movementSpeed) * movementDistance;
        Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);

        // Move object to new position
        transform.position = newPosition;

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
