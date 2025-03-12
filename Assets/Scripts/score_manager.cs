using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;


public class score_manager : MonoBehaviour
{
    public static score_manager instance;
    public TMP_Text score_text;
    public static int score =  0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score_text.text = score.ToString() + " Points";
        
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void addPoints()
    {
        score += 1;
        score_text.text = score.ToString() + " Points";

    }
    
}
