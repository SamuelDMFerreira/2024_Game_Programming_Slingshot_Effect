using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int playerID;
    public float damage = 1.0f;

    public float Damage { get => damage; }

    public int PlayerID { get; set; }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().PlayerNumber != PlayerID)
            {
                Destroy(this.gameObject);
            }
        }

        Debug.Log(other);
    }
}
