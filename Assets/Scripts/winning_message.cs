using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;


public class winning_message : MonoBehaviour
{
     public static winning_message instance;
    public TMP_Text winning_text;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //winning_message.text = score.ToString() + " Points";
        //Hide the winning message initiailly
        winning_text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Check if score is greater than 8
        if(score_manager.score >= 8)
        {
            winning_text.text = "YOU WIN";
        }
        else 
        {
            //Keep it hidden if score is 8 or less
            winning_text.text = "";
        }

    }

    
}
