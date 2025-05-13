using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        //  // shooting Logic
        // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


        Vector3 spawnPosition = firePoint.position + firePoint.right * 0.1f;
        GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, firePoint.rotation);

        // Ignore collision between the bullet and the player
        Collider2D bulletCollider = newBullet.GetComponent<Collider2D>();
        Collider2D playerCollider = GetComponentInParent<Collider2D>(); // Assuming Weapon is a child of the Player

        if (bulletCollider != null && playerCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, playerCollider);
            Debug.Log("Ignoring collision between bullet and player");
            Debug.DrawRay(firePoint.position, firePoint.right * 2f, Color.red, 2f);

        }
    }
}
