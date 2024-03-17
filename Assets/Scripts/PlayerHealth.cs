using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameObject player;
    public float maxHealth;
    private float currentHealth;
    private int playerNumber;

    public float CurrentHealth { get => currentHealth; }

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
        playerNumber = player.GetComponent<PlayerController>().playerNumber;
        currentHealth = maxHealth;
    }

    /// <summary>
    /// If the player takes damage, update the health
    /// </summary>
    /// <param name="dmg"> Dmg taken </param>
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        GameManager.instance.UpdateHealth(playerNumber, currentHealth, maxHealth);
    }

    private void Update()
    {
        // For testing purposes
        if (Input.GetKeyDown(KeyCode.K) && playerNumber == 1)
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.L) && playerNumber == 2)
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player is hit by a projectile, take damage
        if (other.gameObject.name == "Projectile")
        {
            var damage = other.gameObject.GetComponent<ProjectileController>().damage;

            TakeDamage(damage);
        }
    }

    public bool NoHealth()
    {
        return currentHealth <= 0;
    }
}
