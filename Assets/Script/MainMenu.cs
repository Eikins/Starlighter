using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public GameObject style;
    public float transitionTime = 1f;

    public void Start()
    {
        style.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionMenu()
    {
        style.SetActive(true);
        StartCoroutine(LoadMenu("OptionMenu"));
    }

    public void InfoMenu()
    {
        style.SetActive(true);
        StartCoroutine(LoadMenu("HistoryMenu"));
    }

    IEnumerator LoadMenu(string menu)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(menu);
    }



}
