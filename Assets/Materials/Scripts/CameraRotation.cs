using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

     void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }

     void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;                  // Vertical rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limit vertical rotation to 90 degrees up and down

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Rotate camera around the X axis
        playerBody.Rotate(Vector3.up * mouseX);  // Rotate player body around the Y axis for horizontal movement
    }
}
