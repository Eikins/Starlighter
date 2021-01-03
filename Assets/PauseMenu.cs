using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    

    public Animator transition;
    public GameObject style;
    public float transitionTime = 1f;

    private void Start()
    {
        if(style!=null) style.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
         
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if(pauseMenuUI!=null) pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        if(style!=null) style.SetActive(true);
        pauseMenuUI.SetActive(false);
        StartCoroutine(LoadMenu("MainMenu"));
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadMenu(string menu)
    {
        if(transition!=null)
            transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(menu);
    }

}
