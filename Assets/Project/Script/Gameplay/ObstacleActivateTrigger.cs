using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleActivateTrigger : MonoBehaviour
{
    #region Fields
    [SerializeField]
    public List<Obstacle> obstacles;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach(Obstacle o in obstacles)
            {
                o.Activate();
            }
        }
    }
}
