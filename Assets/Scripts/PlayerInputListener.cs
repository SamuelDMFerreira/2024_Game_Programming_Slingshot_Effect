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

    // Controls
    private bool isThrusting = false;
    private bool isBoosting = false;
    private float turnFactor = 0.0f;

    void Start()
    {
        playerCtrl = GetComponent<PlayerController>();
        bulletCtrl = GetComponent<ProjectileController>();
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

    public void OnThrust(InputValue inputVal)
    {
        isThrusting = inputVal.isPressed;
    }

    public void OnBoost(InputValue inputVal)
    {
        isBoosting = inputVal.isPressed;
    }

    public void OnTurn(InputValue inputVal)
    {
        turnFactor = inputVal.Get<float>();
    }

    public void OnFire()
    {
        bulletCtrl.LaunchProjectile();
    }

    public void OnLooktoward()
    {
        Debug.Log("I HAVE EYES");
    }
}
