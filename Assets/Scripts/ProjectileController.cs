using UnityEngine;

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

    void LaunchProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * launchForce);
            rb.velocity += this.GetComponent<Rigidbody>().velocity;
            //this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        // Destroy the projectile after 'lifetime' seconds
        Destroy(projectile, lifetime);
    }
}
