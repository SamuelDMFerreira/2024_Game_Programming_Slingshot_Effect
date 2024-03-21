using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float minimumDistanceThreshold;
    [SerializeField]
    private float damageFactor;
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    private int playerID;
    private GameObject Jupiter;
    private float orbitRadius;

    public float CurrentHealth { get => currentHealth; }

    void Start()
    {
        playerID = GetComponent<PlayerController>().PlayerID;
        currentHealth = maxHealth;

        Jupiter = GameObject.Find("Jupiter");
        orbitRadius = Jupiter.GetComponent<OrbitController>().orbitRadius;
    }

    void Update()
    {
        float distance = Vector3.Distance(Jupiter.transform.position, transform.position);

        if (distance <= orbitRadius && distance < minimumDistanceThreshold)
        {
            TakeOrbitDamage(distance);
        }
    }

    /// <summary>
    /// Takes damage from the player's health
    /// </summary>
    /// <param name="dmg"> Amount to take damage</param>
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        GameManager.instance.UpdateHealth(playerID, currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Calculate the damage the player takes based on the distance from Jupiter
    /// </summary>
    /// <param name="distance"> Distance from Jupiter </param>
    private void TakeOrbitDamage(float distance)
    {
        // Calculate the damage multiplier based on the distance from Jupiter (the closer, the higher the damage)
        float distanceFactor = Mathf.Pow(1.0f - (distance / orbitRadius), 2.0f);

        TakeDamage(damageFactor * distanceFactor * maxHealth * Time.deltaTime);

        Debug.Log("Player " + playerID + " is " + distance + " units away from Jupiter. Taking " + damageFactor * maxHealth * Time.deltaTime + " damage per second.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player got hit by a projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();

            // Check if the projectile hit a player that is not the owner
            if (projectile.PlayerID != playerID)
            {
                TakeDamage(projectile.Damage);
            }
        }
    }
}
