using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDcontroller : MonoBehaviour
{

    #region parameters

    public Image h1;
    public Image h2;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this function is obviously very bad. blame Tao when there is an issue on it, he made it to be quicker (the bastard). the whole class should be remade properly in fact
    public void inflictDamage(int dmg)
    {
        if (dmg == 1)
        {
            if (h2.gameObject.activeSelf)
            {
                h2.gameObject.SetActive(false);
            }
            else if (h1.gameObject.activeSelf)
            {
                h1.gameObject.SetActive(false);
            }
        }
        else
        {
            h2.gameObject.SetActive(false);
            h1.gameObject.SetActive(false);
        }
        
    }

}
