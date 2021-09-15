using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    PlayerController player;
    [SerializeField]
    private GameObject FirePoint;
    Animator anim;
    int bullets = 50;
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip bulletclip;
    public static GunController instance;
    public Text bulletsText;
    
    public GameObject bulletEffect;
    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Blend", 0);
        if (player != null)
        {
            if (bullets > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    FireGun();
                    audioSource.clip = bulletclip;
                    audioSource.Play();
                    bullets--;
                    bulletsText.text = "Bullets: " + bullets;
                    anim.SetFloat("MoveX", 1.0f);
                    anim.SetFloat("MoveZ", 0.0f);

                }
                else
                {
                    anim.SetFloat("MoveX", 0.0f);
                    anim.SetFloat("MoveZ", 0.0f);
                    bulletEffect.SetActive(false);
                }
                
            }
            else
            {
                
                print("Reload");
                if (Input.GetKeyDown(KeyCode.R))
                {
                    bullets = 10;
                }
            }


        }
    }

    public void FireGun()
    {

        bulletEffect.SetActive(true);

       
        Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.right * 50.0f, Color.blue, 1.0f);
        Ray ray = new Ray(FirePoint.transform.position, FirePoint.transform.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            print(hit.collider.gameObject.name);
            if (hit.collider.tag == "Enemy")
            {
                EnemyShoot.instance.EnemyHealth(1);
            }
        }
    }
}
