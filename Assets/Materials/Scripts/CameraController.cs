using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // The player to follow
    public float sensitivity = 3.0f; // How fast the camera moves with the mouse
    public float distance = 5.0f; // How far the camera stays from the player

    private float rotationX = 0f; // Horizontal rotation
    private float rotationY = 0f; // Vertical rotation

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Input.GetMouseButton(2))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;


        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Adjust rotations based on mouse input
        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -45f, 45f); // Limit vertical rotation

        // Calculate the new camera position
        Vector3 direction = new Vector3(0, 0, -distance); // Move the camera backward by "distance"
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0); // Apply rotation
        transform.position = player.transform.position + rotation * direction;

        // Make the camera look at the player
        transform.LookAt(player.transform.position);
    }
}
