using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Fields

    [SerializeField]
    public bool activable=false;

    [SerializeField]
    public Vector3 movementDirection = new Vector3(0.0f,0.0f,0.0f);

    [SerializeField]
    public float speed;

    [SerializeField]
    public float lifeTimeAfterActivation=10.0f;

    [SerializeField]
    public int damage = 1;

    private Rigidbody rb;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        rb.velocity = movementDirection.normalized * speed;
        Destroy(gameObject, lifeTimeAfterActivation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //code for damaging player here
        }
    }
}
