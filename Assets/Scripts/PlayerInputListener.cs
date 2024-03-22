/// <summary>
/// Listens for input actions, most likely sent from PlayerInput
/// component, and handles them properly; Converts input events
/// into controller calls.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(ProjectileController))]
public class PlayerInputListener : MonoBehaviour
{
    private PlayerController playerCtrl;
    private ProjectileController bulletCtrl;
    [SerializeField] private CameraController cameraCtrl;

    // Controls
    private bool isThrusting = false;
    private bool isBoosting = false;
    private float turnFactor = 0.0f;

    void Start()
    {
        playerCtrl = GetComponent<PlayerController>();
        bulletCtrl = GetComponent<ProjectileController>();

        // Lock cursor for camera
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrusting)
            playerCtrl.ApplySmallThrust();
        if (isBoosting)
            playerCtrl.ApplyEscapeThrust();
        playerCtrl.HandleInputRotation(turnFactor);
    }

    private void OnThrust(InputValue inputVal)
    {
        isThrusting = inputVal.isPressed;
    }

    private void OnBoost(InputValue inputVal)
    {
        isBoosting = inputVal.isPressed;
    }

    private void OnTurn(InputValue inputVal)
    {
        turnFactor = inputVal.Get<float>();
    }

    private void OnFire()
    {
        bulletCtrl.LaunchProjectile();
    }

    private void OnLooktoward(InputValue inputVal)
    {
        Vector2 posDiff = inputVal.Get<Vector2>();
        cameraCtrl.UpdateCameraPos(posDiff);
    }
}
