using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float launchForce = 700f;
    public float lifetime = 5f; // Lifetime of the projectile in seconds

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchProjectile();
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    // enable gravitional effects for a projectile with attracted. 
    IEnumerator turnOn(GravitonallyAttracted ga)
    {
        yield return new WaitForSeconds(1.0f);
        ga.Attracted = true;
    }

    void LaunchProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        GravitonallyAttracted ga = projectile.GetComponent<GravitonallyAttracted>();
        if (rb != null && ga != null)
        {
            ga.Attracted = false;
            rb.AddForce(transform.forward * launchForce);
            StartCoroutine(turnOn(ga));
        }

        // Destroy the projectile after 'lifetime' seconds
        Destroy(projectile, lifetime);
    }
}
