using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilEnemy : MonoBehaviour
{
   private Transform player;
   public float Speed;
   public float lineOfSight;
   public int health = 100;
   public int damage = 1;
   public GameObject deathEffect;
   private SpriteRenderer spriteRenderer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float distanceFromPlayer= Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);
            spriteRenderer.flipX = player.position.x > transform.position.x;   
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        StartCoroutine(BlinkRed());  // Start blinking when hit
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
