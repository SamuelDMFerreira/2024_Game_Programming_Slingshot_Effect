using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float CurrentHealth { get => currentHealth; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// If the player takes damage, update the health
    /// </summary>
    /// <param name="dmg"> Dmg taken </param>
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        GameManager.instance.UpdateHealth(currentHealth, maxHealth);
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
