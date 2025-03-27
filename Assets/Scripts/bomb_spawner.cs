using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bomb_spawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float r; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //will load 10 bombs at the start of the game 
        for(int i = 0; i < 5; i++)
        {
            //spawObject(); take off the comment to spawn bombs/villains 
        }

    }

    // Update is called once per frame
    void Update()
   {    /*
        if(Input.GetKeyDown(KeyCode.B))
        {
            spawObject();
        }
        */
    }

    void spawObject()
    {
        Vector3 randomPos = Random.insideUnitCircle * r; 
        Instantiate(itemPrefab, randomPos, Quaternion.identity);

    }
}
