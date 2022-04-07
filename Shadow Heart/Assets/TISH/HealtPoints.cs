using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealtPoints : MonoBehaviour
{
    public float hp;

    public void Update()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene(sceneName: "gameOver");
        }
    }
}
