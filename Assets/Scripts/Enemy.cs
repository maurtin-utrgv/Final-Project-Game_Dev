// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     private Transform player;
//     public float Speed;
//     public float lineOfSight;
//     public float shootingRange;
//     public GameObject bullet;
//     public GameObject bulletParent;
//     public float fireRate = 2f;
//     private float nextFireTime;
//     public int health = 100;
//     public GameObject deathEffect;
//     private SpriteRenderer spriteRenderer;

//     void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         spriteRenderer = GetComponent<SpriteRenderer>();
//     }

//     void Update()
//     {
//         float distanceFromPlayer= Vector2.Distance(player.position, transform.position);
//         if (distanceFromPlayer < lineOfSight && distanceFromPlayer>shootingRange)
//         {
//             transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);   
//             spriteRenderer.flipX = player.position.x > transform.position.x;
//         }
//         else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
//         {
//             Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
//             nextFireTime = Time.time + fireRate;
//         }
//     }   

//     private void OnDrawGizmosSelected()
//     {
//         Gizmos.color = Color.green;
//         Gizmos.DrawWireSphere(transform.position, lineOfSight);
//         Gizmos.DrawWireSphere(transform.position, shootingRange);
//     }   


//     public void TakeDamage (int damage)
//     {
//         health -= damage;
//         StartCoroutine(BlinkRed());

//         if (health <= 0)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         Debug.Log($"{gameObject.name} died. Remaining enemies: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
//         Instantiate(deathEffect, transform.position, Quaternion.identity);
//         Destroy(gameObject);
//     }
//     IEnumerator BlinkRed()
//     {
//         Color originalColor = spriteRenderer.color;
//         spriteRenderer.color = Color.red;
//         yield return new WaitForSeconds(0.1f); // Red for 0.1 seconds
//         spriteRenderer.color = originalColor;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public float Speed;
    public float lineOfSight;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 2f;
    private float nextFireTime;
    public int health = 100;
    public GameObject deathEffect;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Debug.Log("Enemy Start() running");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        // Always follow the player if within line of sight
        if (distanceFromPlayer < lineOfSight)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
            spriteRenderer.flipX = player.position.x > transform.position.x;
        }

        // Shoot if within shooting range
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }


 

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                int contactDamage = 2; // or whatever you want
                playerHealth.TakeDamage(contactDamage);
            }
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        StartCoroutine(BlinkRed());

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} died. Remaining enemies: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    IEnumerator BlinkRed()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f); // Red for 0.1 seconds
        spriteRenderer.color = originalColor;
    }

}
