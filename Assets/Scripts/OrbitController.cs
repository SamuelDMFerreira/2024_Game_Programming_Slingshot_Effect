using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public float gravityPull = 9.8f; // Simulated gravitational pull strength
    public float orbitRadius = 10f; // The radius at which objects will be pulled into orbit

    // When the game starts up set the trigger collider radius to the orbitRadius
    void Start()
    {
        float radiusScale = this.transform.localScale.magnitude;
        this.GetComponent<SphereCollider>().radius = orbitRadius / radiusScale;
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody otherRb = other.GetComponent<Rigidbody>();
        GravitonallyAttracted ga = other.GetComponent<GravitonallyAttracted>();
        if (otherRb != null && ga != null && ga.Attracted == true)
        {          
            Vector3 directionToCenter = transform.position - other.transform.position;
            float distance = directionToCenter.magnitude;
            
            otherRb.AddForce(directionToCenter.normalized * gravityPull);
        }
    }
}
