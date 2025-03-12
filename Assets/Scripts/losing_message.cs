using UnityEngine;
using TMPro;

public class losing_message : MonoBehaviour
{
 public static losing_message instance;
    public TMP_Text losing_text;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        losing_text.text = ""; //hide message initially
    }

    private void OnEnable()
    {
        //subscriebe to player death event
        player_dead.OnPlayerDeath += ShowLosingMessage;
    
    }

    private void OnDisable()
    {
        //unsubscribe to avoid memory leaks
        player_dead.OnPlayerDeath -= ShowLosingMessage;
    
    }

    private void ShowLosingMessage()
    {
        losing_text.text = "YOU LOSE";
    }
    /*
    void Start()
    {
    
    }
    */

    /*
    // Update is called once per frame
    void Update()
    { 

    }
    */
}
