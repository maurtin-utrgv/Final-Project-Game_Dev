using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class player_dead : MonoBehaviour
{
    public static event Action OnPlayerDeath; //Event triggered when player dies
    public ParticleSystem collisionParticleSystem;
    public bool once = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bomb_enemy"))
        {
            OnPlayerDeath?.Invoke(); //Notify listeners 
            Destroy(this.gameObject); //Destroy the player
        }

        if(collision.gameObject.CompareTag("power_up"))
        {
            var em = collisionParticleSystem.emission;
            Destroy(collision.gameObject);
            score_manager.instance.addPoints();
            if (once)
            {
                em.enabled = true; 
                collisionParticleSystem.Play();
                once = false;
            }


        }
        
    }
}
