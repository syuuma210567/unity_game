using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LvSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonClick(int num)
    {
        switch (num)
        {
            case 1:
                Game.CPULv = Game.Handicap.Lv1;
                break;
            case 2:
                Game.CPULv = Game.Handicap.Lv2;
                break;
            case 3:
                Game.CPULv = Game.Handicap.Lv3;
                break;

        }
        SceneManager.LoadScene("SampleScene");
    }
}
