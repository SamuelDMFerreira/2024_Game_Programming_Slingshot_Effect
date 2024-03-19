using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    private GameObject player;
    private int playerID;

    public float CurrentHealth { get => currentHealth; }

    void Start()
    {
        player = this.transform.parent.gameObject;
        playerID = player.GetComponent<PlayerController>().PlayerNumber;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        GameManager.instance.UpdateHealth(playerID, currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(player);
        }
    }

    void Update()
    {
        // Test damage
        if (playerID == 1 && Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
        }
        if (playerID == 2 && Input.GetKeyDown(KeyCode.O))
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
}
