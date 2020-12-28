using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    #region parameters

    [SerializeField] public int max_hp;
    private int current_hp;



    #endregion

    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageOnTouch")
        {
            //probably pretty bad, avoid getcomponent
            Obstacle tmp = other.gameObject.GetComponent<Obstacle>();
            current_hp -= tmp.damage;
            //debug purposes
            Debug.Log("Got hit for "+tmp.damage+", old hp : "+(current_hp+tmp.damage)+", remaining hp : "+current_hp);
        }
    }
}
