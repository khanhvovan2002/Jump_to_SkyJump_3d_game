using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement_6 : MonoBehaviour
{
    public float speed = 2f; // speed of the movement
    public float amplitude = 1f; // amplitude of the sin function
    public float frequency = 1f; // frequency of the sin function
    private Vector3 initialPosition;

    public float movementSpeed = 2f;
    public float movementDistance = 2f;
    private Vector3 startPosition;

    public float jumpForce = 5f;
    private bool canJump = false;

    private void Start()
    {
        // store the initial position of the object
        initialPosition = transform.position;
        startPosition = transform.position;
    }

    private void Update()
    {
        // calculate the horizontal movement using sin function
        float horizontalMovement = Mathf.Sin(Time.time * frequency) * amplitude;

        // translate the object horizontally
        Vector3 newPosition = initialPosition + Vector3.right * horizontalMovement;
        transform.position = newPosition;

        // Calculate new position
        float newY = startPosition.y + Mathf.Sin(Time.time * movementSpeed) * movementDistance;
        newPosition = new Vector3(transform.position.x, newY, transform.position.z);

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
