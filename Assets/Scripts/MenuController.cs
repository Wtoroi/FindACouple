using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void LoadLevel(int Number)
    {
        switch (Number) {
            case 1:
                SceneManager.LoadScene("Main");
                break;
            default:
                break;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
