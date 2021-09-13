using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class EnemyShoot : MonoBehaviour
{
    Animator anim;
    //NavMeshAgent agent;
    [SerializeField]
    private GameObject FirePoint;
    [SerializeField]
    private int health;
    public static EnemyShoot instance;
    private PlayerController player;
  
    public int temp;
    public int deathCount;
    public GameObject deatheffect;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
      
        anim = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    void Update()
    {
        if (health <= 0)
        {

            Destroy(this.gameObject);
            deatheffect.SetActive(true);
          
        }
        else
        {
            deatheffect.SetActive(false);
        }
       
            InvokeRepeating("FireGun", 1.0f, 3.0f);
    
    }
    public void FireGun()
    {
        transform.LookAt(player.transform.position);
        Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward * 5.0f, Color.red, Time.deltaTime-10.0f);
        Ray ray = new Ray(FirePoint.transform.position, FirePoint.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.tag == "Player")
            {
                PlayerController.instance.playerhealth(0.1f);
            }
        }
    }
    public void EnemyHealth(int damage)
    {
        health = health - damage;
        
    }
    
}
