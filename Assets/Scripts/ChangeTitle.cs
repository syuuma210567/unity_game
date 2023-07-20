using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard.enterKey.wasPressedThisFrame || keyboard.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
