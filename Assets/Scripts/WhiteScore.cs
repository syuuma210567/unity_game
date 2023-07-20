using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhiteScore : MonoBehaviour
{
    public TextMeshProUGUI whitescore;
    
    void Start()
    {
       
        int score = Game.WhiteScore_;
        whitescore.text = "White   :  " + score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
