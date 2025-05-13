using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public int damage = 40;
    public GameObject impactEffect;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
        Debug.Log("Velocity applied: " + rb.linearVelocity);
    }

    void Update()
    {
        Debug.Log("Current velocity: " + rb.linearVelocity);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Bullet collided with: " + hitInfo.name);

        LilEnemy lilEnemy = hitInfo.GetComponent<LilEnemy>();
        Enemy boss = hitInfo.GetComponent<Enemy>();

        if (lilEnemy != null)
        {
            Debug.Log("Hit LilEnemy, applying damage.");
            lilEnemy.TakeDamage(damage);
        }

        if (boss != null)
        {
            Debug.Log("Hit Boss, applying damage.");
            boss.TakeDamage(damage);
        }

        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("impactEffect is null!");
        }

        Destroy(gameObject);
    }
}
