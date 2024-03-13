using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public float CurrentHealth { get => currentHealth; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        GameManager.instance.UpdateHealth(currentHealth, maxHealth);
    }

    private void Update()
    {
        // For testing purposes
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(10);
            Debug.Log("Current Health: " + currentHealth);
        }
    }
}
