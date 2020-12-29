using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("MainScene");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionMenu()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void InfoMenu()
    {

    }

}
