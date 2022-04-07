using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverButton : MonoBehaviour
{
    public void menuButton()
    {
        SceneManager.LoadScene(sceneName: "mainMenu");
    }
}
