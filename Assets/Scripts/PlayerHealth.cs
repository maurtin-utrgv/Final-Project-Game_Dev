using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public healthUI healthUI;
    private SpriteRenderer spriteRenderer;
    public static event Action OnPlayerDied;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LilEnemy enemy = collision.GetComponent<LilEnemy>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
        // Check for deathzone collision
        if (collision.CompareTag("DeathZone"))
        {
            Debug.Log("Player touched DeathZone");
            TakeDamage(currentHealth); // This will set the health to 0 and trigger the death
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage: " + damage);
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        StartCoroutine(FlashRed());

        if(currentHealth <= 0)
        {
            Debug.Log("Player died"); // Debug to confirm
            OnPlayerDied?.Invoke();

        }
    }

    private IEnumerator FlashRed()
    {
        Color originalColor = spriteRenderer.color; // Save original color
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor; // Revert to original color
    }
    public void TryRestoreHeart()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            healthUI.UpdateHearts(currentHealth);
        }
    }

}
