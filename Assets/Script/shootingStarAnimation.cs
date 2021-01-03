using UnityEngine;
using System.Collections;

public class shootingStarAnimation : MonoBehaviour
{
    public GameObject Trail;
    public AnimationClip anim;
    Animator myAnimator;
    float waitTime;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        waitTime = anim.length + 6f;
        InvokeRepeating("PlayAnim", 6f, waitTime);
    }

    // Update is called once per frame
    void PlayAnim()
    {
       
        
        myAnimator.SetTrigger("Restart");
        Trail.SetActive(true);
        Trail.SetActive(false);
        Trail.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        Trail.SetActive(true);
    }
}