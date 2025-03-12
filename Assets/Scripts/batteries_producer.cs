using UnityEngine;

public class batteries_producer : MonoBehaviour
{
    public GameObject itemPrefab;
    //public GameObject particles; 
    public float spawnRadius = 5f;  // Replaced 'r' with 'spawnRadius' for clarity
    public Vector2 spawnCenter = Vector2.zero; // Center of the spawn area
    public float safeRadius = 1.5f; // Safe distance from player
    public Transform player; // Reference to player to avoid spawning on them

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //will load 10 bombs at the start of the game 
        for(int i = 0; i < 10; i++)
        {
            spawObject();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.B))
        //{
            //spawObject();
        //}
    }

    void spawObject()
    {
        Vector2 randomPos = spawnCenter; // Default position
        bool validSpawn = false;

        for (int attempts = 0; attempts < 10; attempts++) // Try 10 times
        {
            Vector2 potentialPos = spawnCenter + (Random.insideUnitCircle * spawnRadius);

            // Ensure it doesn't spawn too close to the player
            if (Vector2.Distance(potentialPos, player.position) >= safeRadius)
            {
                randomPos = potentialPos;
                validSpawn = true;
                break;
            }
        }

        // Spawn the battery at the final position
        Instantiate(itemPrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);

    }
}
