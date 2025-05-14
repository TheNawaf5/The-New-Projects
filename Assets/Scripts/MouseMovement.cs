using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    
    public float mouseSesitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        //Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSesitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSesitivity * Time.deltaTime;

        // Rotate around the x axis
        xRotation -= mouseY;

        // Clamp the rotation to prevent flipping
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}