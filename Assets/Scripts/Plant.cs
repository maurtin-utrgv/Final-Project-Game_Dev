using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plant: MonoBehaviour, IItem
{
   public void Collect()
    {
       GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null && playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.TryRestoreHeart();
                Destroy(gameObject);
            }
        }
    }

}
