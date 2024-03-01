using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public float gravityPull = 9.8f; // Simulated gravitational pull strength
    public float orbitRadius = 10f; // The radius at which objects will be pulled into orbit
    /*public float minDistance = 2f; // Minimum allowed distance between the two objects to prevent them from touching
    public float orbitalSpeed = 5f; // Desired constant speed for objects in orbit*/

    // When the game starts up set the trigger collider radius to the orbitRadius
    void Start()
    {
        float radiusScale = this.transform.localScale.magnitude;
        this.GetComponent<SphereCollider>().radius = orbitRadius / radiusScale;
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody otherRb = other.GetComponent<Rigidbody>();
        if (otherRb != null)
        {
            Vector3 directionToCenter = transform.position - other.transform.position;
            float distance = directionToCenter.magnitude;

            /*if (distance < orbitRadius)
            {
                // Check if the distance is less than the minimum allowed distance
                if (distance < minDistance)
                {
                    // Apply a repulsive force to push the object away
                    float repulsiveForceMagnitude = Mathf.Clamp((minDistance - distance) / minDistance, 0, 1) * gravityPull;
                    otherRb.AddForce(-directionToCenter.normalized * repulsiveForceMagnitude);
                }
                else
                {
                    // Apply a force towards the center to simulate gravity
                    otherRb.AddForce(directionToCenter.normalized * gravityPull);

                    // Apply a tangential force to make the object orbit at the desired constant speed
                    Vector3 tangentialDirection = Quaternion.Euler(0, 90, 0) * directionToCenter.normalized;
                    otherRb.velocity = tangentialDirection * orbitalSpeed; 
                }
            }*/
            otherRb.AddForce(directionToCenter.normalized * gravityPull);
        }
    }
}
