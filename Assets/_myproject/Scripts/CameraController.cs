using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSensitivity = 5.0f; // Sensitivity of the rotation
    private Vector3 offset; // Initial offset from the player
    private float yaw = 0.0f; // Yaw rotation around the Y axis
    private float pitch = 0.0f; // Pitch rotation around the X axis
    private float returnDelay = 1.0f; // Delay before the camera starts moving back
    private float returnTimer = 0.0f; // Timer to track the delay
    private bool isReturning = false; // Flag to check if camera is returning to default position

    void Start()
    {
        ResetCameraPosition();
    }

    void LateUpdate()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            yaw += rotationSensitivity * Input.GetAxis("Mouse X");
            pitch -= rotationSensitivity * Input.GetAxis("Mouse Y");

            // Clamp the pitch rotation to prevent flipping
            pitch = Mathf.Clamp(pitch, -89f, 89f);

            returnTimer = 0.0f; // Reset the timer
            isReturning = false; // User is actively controlling the camera
        }
        else
        {
            // Start the return timer if the mouse button is not being held down
            returnTimer += Time.deltaTime;

            if (returnTimer >= returnDelay)
            {
                isReturning = true;
            }
        }

        if (isReturning)
        {
            // Smoothly interpolate the yaw and pitch rotations back to align with the player's forward direction
            ResetCameraRotation();
        }

        // Update the camera's rotation
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Update the camera's position based on the player's position and the initial offset
        transform.position = player.position + Quaternion.Euler(0, yaw, 0) * offset;

        // Check for a key press to reset the camera position manually, e.g., pressing 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCameraPosition();
        }
    }

    void ResetCameraPosition()
    {
        offset = transform.position - player.position; // Recalculate the initial offset
        transform.position = player.position + offset; // Reset the camera's position
        yaw = player.eulerAngles.y; // Align the camera's yaw with the player's orientation
        pitch = 0.0f; // Reset the pitch
    }

    void ResetCameraRotation()
    {
        // Smoothly interpolate the yaw rotation back to align with the player's forward direction
        Quaternion targetRotation = Quaternion.LookRotation(player.forward);
        Quaternion currentRotation = Quaternion.Euler(pitch, yaw, 0);
        Quaternion smoothRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSensitivity);
        yaw = smoothRotation.eulerAngles.y;
        pitch = Mathf.Lerp(pitch, 0, Time.deltaTime * rotationSensitivity); // Optionally reset pitch as well
    }
}
