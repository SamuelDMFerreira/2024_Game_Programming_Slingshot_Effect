using UnityEngine;
using UnityEngine.Windows;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSensitivity = 5.0f; // Sensitivity of the rotation
    private Vector3 offset; // Initial offset from the player
    private float yaw = 0.0f; // Yaw rotation around the Y axis
    private float pitch = 0.0f; // Pitch rotation around the X axis
    private float returnDelay = 0.1f; // Delay before the camera starts moving back
    private float returnTimer = 0.0f; // Timer to track the delay
    private bool isReturning = false; // Flag to check if camera is returning to default position

    void Start()
    {
        ResetCameraPosition();
    }
    /// <summary>
    /// Updates the camera position and rotation based on player input and automatic return behavior.
    /// </summary>
    void LateUpdate()
    {
        // Update the return timer and check if the camera should start returning to default position
        if (!isReturning)
        {
            returnTimer += Time.deltaTime;
            if (returnTimer >= returnDelay)
            {
                isReturning = true;
            }
        }

        // Handle the camera's automatic return to its default orientation
        if (isReturning)
        {
            ResetCameraRotation();
        }

        // Always update the camera's rotation and position based on the current yaw and pitch
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.position = player.position + Quaternion.Euler(0, yaw, 0) * offset;

    }
    /// <summary>
    /// Resets the camera to its initial position offset from the player.
    /// </summary>
    void ResetCameraPosition()
    {
        offset = transform.position - player.position; // Recalculate the initial offset
        transform.position = player.position + offset; // Reset the camera's position
        yaw = player.eulerAngles.y; // Align the camera's yaw with the player's orientation
        pitch = 0.0f; // Reset the pitch
    }
    /// <summary>
    /// Gradually resets the camera rotation to align with the player's forward direction.
    /// </summary>
    void ResetCameraRotation()
    {
        // Smoothly interpolate the yaw rotation back to align with the player's forward direction
        Quaternion targetRotation = Quaternion.LookRotation(player.forward);
        Quaternion currentRotation = Quaternion.Euler(pitch, yaw, 0);
        Quaternion smoothRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSensitivity);
        yaw = smoothRotation.eulerAngles.y;
        pitch = Mathf.Lerp(pitch, 0, Time.deltaTime * rotationSensitivity); // Optionally reset pitch as well
    }

    /// <summary>
    /// Updates the camera's yaw and pitch based on the given position difference.
    /// </summary>
    /// <param name="positionDifference">The difference in position to use for updating the camera's orientation.</param>
    public void UpdateCameraPos(Vector2 positionDifference)
    {
        yaw += rotationSensitivity * positionDifference.x;
        pitch -= rotationSensitivity * positionDifference.y;
        pitch = Mathf.Clamp(pitch, -89f, 89f); // Clamp the pitch rotation to prevent flipping

        // Reset the return timer and flag as soon as there's input, indicating the user is controlling the camera
        returnTimer = 0.0f;
        isReturning = false;
    }
}
