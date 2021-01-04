using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionTrigger : MonoBehaviour
{

    #region params

    public string LevelToLoad;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //code for scene change
            Invoke("LoadLevel", 2.0f);
        }
        
    }

}
