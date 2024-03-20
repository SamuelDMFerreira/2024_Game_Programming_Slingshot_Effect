using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage = 1.0f;
    private int playerID;

    public float Damage { get => damage; }

    public int PlayerID { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>().PlayerID != this.PlayerID)
            {
                Debug.Log("Projectile hit player " + collision.gameObject.GetComponent<PlayerController>().PlayerID);
                Destroy(this.gameObject);
            }
        }
    }
}
