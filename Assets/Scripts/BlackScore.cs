using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackScore : MonoBehaviour
{
    public TextMeshProUGUI blackscore;

    // Start is called before the first frame update
    void Start()
    {
        int score = Game.BlackScore_;
        blackscore.text = "Black   :  " + score.ToString();
        blackscore.color = Color.black;
    }

}
