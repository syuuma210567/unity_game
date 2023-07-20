using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultText : MonoBehaviour
{
    public TextMeshProUGUI result;

    void Start()
    {
        if (Game.Result == Game.ResultText.BlackWin)
        {
            result.text = "Black Win!";
            result.color = Color.black;
        }
        else if(Game.Result == Game.ResultText.Draw)
        {
            result.text = "Draw";
        }
        else if(Game.Result == Game.ResultText.WhiteWin)
        {
            result.text = "White Win!";
        }
        else 
        { 
            result.text = "error"; 
            result.color = Color.red;
        }
    }
}