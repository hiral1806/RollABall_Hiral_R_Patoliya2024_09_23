using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject player;           // Reference to the player GameObject
    public float mouseSensitivity = 100f; // Sensitivity of the mouse
    public Vector3 offset;             // Offset between player and camera

    private float xRotation = 0f;      // Current vertical rotation of the camera
    private Transform playerBody;      // Reference to the player's body (optional)

    void Start()
    {
        // Lock the cursor to the game window and make it invisible
        Cursor.lockState = CursorLockMode.Locked;

        // Calculate initial offset if not manually set
        if (offset == Vector3.zero)
            offset = transform.position - player.transform.position;

        // Assign player body if not manually set
        playerBody = player.transform;
    }

    void LateUpdate()
    {
        // Update camera position to maintain offset
        transform.position = player.transform.position + offset;

        // Handle camera rotation
        HandleRotation();
    }

    void HandleRotation()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera vertically (up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation

        // Apply the vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally (left and right) if playerBody is assigned
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
