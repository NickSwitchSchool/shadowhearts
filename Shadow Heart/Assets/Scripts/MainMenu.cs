using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(sceneName: "game");
    }
    public void QuitButton()
    {
        Application.Quit();
        print("Normally the game would have quit, but that doesn't work in the editor, so you get this print instead to make you happy!");
    }
}
