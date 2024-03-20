using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    private int playerID;

    public float CurrentHealth { get => currentHealth; }

    void Start()
    {
        playerID = GetComponent<PlayerController>().playerID;
        currentHealth = maxHealth;

        Debug.Log("Player " + playerID + " has " + currentHealth + " health");
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
