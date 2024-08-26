using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OutMap : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 respawnPos;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    Vector3 line;
    void Start()
    {
        respawnPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            this.transform.position = Vector3.zero;
            Debug.Log("Click");
    }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.transform.position = Vector3.zero;
        }
        // Reset position, rotation, health, and ammo when the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetController();
        }


    }
    void ResetController()
    {
        // Reset position and rotation
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        // Reload the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("Scene has been reset.");
    }

        void OnDisable()
    {
        // Save the position before disabling the script (optional)
        Debug.Log("Saving position before script disables: " + this.transform.position);
    }

    void OnEnable()
    {
        // Restore the respawn position when the script is enabled (optional)
        Debug.Log("Script enabled, current respawn position: " + respawnPos);
    }
}
