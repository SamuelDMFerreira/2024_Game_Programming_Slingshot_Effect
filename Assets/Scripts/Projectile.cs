using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage = 1.0f;

    public float Damage { get => damage; }

    public int PlayerID { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the projectile hit a player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the projectile hit a player that is not the owner
            if (collision.gameObject.GetComponent<PlayerController>().PlayerID != this.PlayerID)
            {
                Debug.Log("Projectile hit player " + collision.gameObject.GetComponent<PlayerController>().PlayerID);
                Destroy(this.gameObject);
            }
        }
    }
}
