using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonClick(int num)
    {
        switch (num)
        {
            case 1:
                SceneManager.LoadScene("HandiCapScene");
                break;
            case 2:
                SceneManager.LoadScene("PvPScene");
                break;

        }
    }
}
