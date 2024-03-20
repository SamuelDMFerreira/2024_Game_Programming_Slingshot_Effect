using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float launchForce = 700f;
    public float lifetime = 5f; // Lifetime of the projectile in seconds

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    // enable gravitional effects for a projectile with attracted. 
    IEnumerator turnOn(GravitonallyAttracted ga)
    {
        yield return new WaitForSeconds(0.5f);
        ga.Attracted = true;
    }


    public void LaunchProjectile()
    {
        Vector3 launchPosition = transform.position + (transform.forward * 2.0f);

        Debug.Log("Launching projectile");
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().PlayerID = this.gameObject.GetComponent<PlayerController>().PlayerID;
        SoundManager.Instance.PlaySoundEffect("projectile");

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        GravitonallyAttracted ga = projectile.GetComponent<GravitonallyAttracted>();
        if (rb != null && ga != null)
        {
            // temporary disable projection gravitional attraction and set it to have same initial velocity as ship
            ga.Attracted = false;
            //rb.velocity = this.gameObject.GetComponent<Rigidbody>().velocity;
            rb.AddForce(transform.forward * launchForce);
            StartCoroutine(turnOn(ga));
        }

        // Destroy the projectile after 'lifetime' seconds
        Destroy(projectile, lifetime);
    }
}
