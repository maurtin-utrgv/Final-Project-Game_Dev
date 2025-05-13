// using UnityEngine;

// public class EnemyBullet : MonoBehaviour
// {
//     GameObject target;
//     public float Speed = 5f;
//     Rigidbody2D bulletRB;

//     void Start()
//     {
//         bulletRB = GetComponent<Rigidbody2D>();
//         target = GameObject.FindGameObjectWithTag("Player");

//         if (target != null)
//         {
//             Vector2 moveDir = (target.transform.position - transform.position).normalized * Speed;
//             bulletRB.linearVelocity = moveDir;
//         }
//     }

//     void OnTriggerEnter2D(Collider2D hitInfo)
//     {
//         PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
//         if (playerHealth != null)
//         {
//             int damage = 1;
//             playerHealth.TakeDamage(damage);
//         }

//         // Destroy bullet when hitting anything
//         if (!hitInfo.CompareTag("Enemy")) // Optional: ignore hitting the shooter
//         {
//             Destroy(gameObject);
//         }
//     }
// }



using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    GameObject target;
    public float Speed;
    Rigidbody2D bulletRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir= (target.transform.position - transform.position).normalized * Speed;
        bulletRB.linearVelocity = new Vector2(moveDir.x, moveDir.y);

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            int damage = 1; // or make this a public variable if you want to customize per bullet
            playerHealth.TakeDamage(damage);
        }

        Destroy(gameObject); // Destroy the enemy bullet on impact
    }  
}
