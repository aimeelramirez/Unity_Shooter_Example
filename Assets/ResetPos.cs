using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    // The initial position to reset the controller to
    private Vector3 initialPosition;
    // Optionally, the initial rotation if you want to reset that too
    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial position and rotation when the game starts
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetControllerPosition();
        }
    }

    // Function to reset the position and rotation of the controller
    void ResetControllerPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        Debug.Log("Controller position reset.");
    }
}