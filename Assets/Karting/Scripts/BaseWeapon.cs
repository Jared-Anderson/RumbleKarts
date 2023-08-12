using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public float damage = 10f;
    public float raycastDuration = 1f; // Duration in seconds for the raycast
    public float fireRate = 2.0f; // Shots per second
    private float fireTimer = 0.0f;

    private bool isFiring = false;

    private GameObject projectilePrefab;

    private void Start()
    {
        // Update the timer
        fireTimer += Time.deltaTime;

        // Check if it's time to fire based on the fire rate
        if (Input.GetButtonDown("Use") && fireTimer >= 1.0f / fireRate)
        {
            Fire();
            fireTimer = 0.0f; // Reset the timer
        }
    }

    public virtual void Fire()
    {
        Transform fireStartPosition = gameObject.transform;
        // Instantiate the projectile prefab at the weapon's position and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, fireStartPosition.position, fireStartPosition.rotation);

        if (!isFiring)
        {
            isFiring = true;
        }
    }

    //private System.Collections.IEnumerator FireRaycast()
    //{
    //    float timer = 0f;

    //    while (timer < raycastDuration)
    //    {
    //        RaycastHit hit;

    //        if (Physics.Raycast(transform.position, transform.forward, out hit))
    //        {
    //            // Deal damage or perform other interactions with hit objects here
    //        }

    //        timer += Time.deltaTime;
    //        yield return null;
    //    }

    //    isFiring = false;
    //}
}
