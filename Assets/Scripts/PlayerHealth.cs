using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float damageFactor;
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    private int playerID;

    public float CurrentHealth { get => currentHealth; }

    void Start()
    {
        playerID = GetComponent<PlayerController>().PlayerID;
        currentHealth = maxHealth;
    }

    void Update()
    {
        GameObject Jupiter = GameObject.Find("Jupiter");
        float orbitRadius = Jupiter.GetComponent<OrbitController>().orbitRadius;
        float distance = Vector3.Distance(Jupiter.transform.position, transform.position);

        if (distance <= orbitRadius && distance < 80.0f)
        {
            TakeOrbitDamage(distance, orbitRadius);
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        GameManager.instance.UpdateHealth(playerID, currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeOrbitDamage(float distance, float orbitRadius)
    {
        // Calculate the damage multiplier based on the distance from Jupiter (the closer, the higher the damage)
        float distanceFactor = Mathf.Pow(1.0f - (distance / orbitRadius), 2.0f);

        TakeDamage(damageFactor * distanceFactor * maxHealth * Time.deltaTime);

        Debug.Log("Player " + playerID + " is " + distance + " units away from Jupiter. Taking " + damageFactor * maxHealth * Time.deltaTime + " damage per second.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the player is hit by a projectile, take damage
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();

            // Got hit by an enemy projectile
            if (projectile.PlayerID != playerID)
            {
                TakeDamage(projectile.Damage);
            }
        }
    }
}
