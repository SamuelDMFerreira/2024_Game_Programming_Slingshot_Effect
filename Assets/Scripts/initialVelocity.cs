using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialVelocity : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;

    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = velocity;
    }
}
