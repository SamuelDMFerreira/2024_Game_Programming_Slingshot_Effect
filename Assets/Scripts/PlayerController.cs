using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public float maxSpeed = 20f;
    public float boostMaxSpeed = 30f; // Maximum speed during the boost
    public float thrustPower = 100f;
    public float boostDuration = 2f; // Duration in seconds to ignore normal max speed after boost
    public float boostCooldown = 5f; // Cooldown duration in seconds before the next boost can be applied

    private Rigidbody rb;
    private float boostTimer = 0f; // Timer to track the boost duration
    private float cooldownTimer = 0f; // Timer to track the boost cooldown
    private bool isBoosting = false;
    private bool canBoost = true; // Flag to check if the boost can be applied, considering the cooldown

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canBoost)
        {
            ApplyEscapeThrust();
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed);
        }

        HandleInputRotation();

   

        // Update the boost timer and handle boost duration
        if (isBoosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostDuration)
            {
                isBoosting = false; // End the boost
                boostTimer = 0f; // Reset the boost timer
                cooldownTimer = 0f; // Start the cooldown timer
            }
        }

        // Update the cooldown timer and handle cooldown duration
        if (!canBoost)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= boostCooldown)
            {
                canBoost = true; // Reset the boost availability after the cooldown ends
            }
        }

        // Apply max speed check, considering whether the player is currently boosting
        if (!isBoosting && rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        else if (isBoosting && rb.velocity.magnitude > boostMaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * boostMaxSpeed;
        }
    }

    void HandleInputRotation()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotation, 0));
    }

    void ApplyEscapeThrust()
    {
        if (canBoost)
        {
            rb.AddForce(transform.forward * thrustPower, ForceMode.Impulse);
            isBoosting = true; // Set the boost flag
            canBoost = false; // Disable further boosting until cooldown is over
            Debug.Log("Escape thrust applied!");
        }
    }
}