using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipManager : MonoBehaviour
{
    #region parameters

    [SerializeField] public int max_hp;
    private int current_hp;

    private AudioSource contact;

    public GameObject missilePrefab;

    public float missileStrength = 2000.0f;
    public float missileLifeTime = 1.0f;

    public HUDcontroller HUD;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;

        contact = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void FireMissile()
    {
        GameObject tmp = Instantiate(missilePrefab, this.transform.position,Quaternion.identity);
        //getting rigidbody is probably unclean here !
        Rigidbody rb = tmp.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * missileStrength);
        Destroy(tmp, missileLifeTime);
    }

    private void InflictDamage(int damage)
    {
        current_hp -= damage;
        HUD.inflictDamage(damage);
        if (current_hp <= 0)
        {
            Invoke("ReloadLevel", 0.6f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageOnTouch")
        {
            //probably pretty bad, avoid getcomponent
            Obstacle tmp = other.gameObject.GetComponent<Obstacle>();

            InflictDamage(tmp.damage);
            contact.Play();
            //debug purposes
            //Debug.Log("Got hit for "+tmp.damage+", old hp : "+(current_hp+tmp.damage)+", remaining hp : "+current_hp);
        }
    }
}
