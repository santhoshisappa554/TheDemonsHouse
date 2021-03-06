using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private CharacterController character;
    Vector3 moveinput;
    [SerializeField]
    private float mouseSenstivity;
    [SerializeField]
    private bool invertX, invertY;
    Vector2 mouseInput;
    private float gravity = 9.81f;
    public LayerMask groundMask;
    Animator anim;
    [SerializeField]
    private float health = 100;
    public Text healthText;
    public static PlayerController instance;
    public int enemydeathCount=0;
    public GameObject KeyEffect;
    public Text hintText;
    float time = 0;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //enemydeathCount = enemydeathCount + EnemyShoot.instance.enemySpawnCount;
       
    }

    // Update is called once per frame
    void Update()
    {
     
        time = time + Time.deltaTime;
        //print(time);
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var horiMove = transform.right * horizontal;
        var verMove = transform.forward * vertical;
        moveinput = horiMove + verMove;
        moveinput *= moveSpeed;
        print(moveinput.z);
        if (moveinput.x > 0.2f)
        {
            anim.SetFloat("MoveX",-1.0f);
            anim.SetFloat("Movez",1.0f);
        }
       else if (moveinput.x < -0.1f)
        {
            anim.SetFloat("MoveX", 1.0f);
            anim.SetFloat("MoveZ", 0.0f);
        }

        else if (moveinput.z > 0.01f)
        {
            anim.SetFloat("MoveX", 0.0f);
            anim.SetFloat("MoveZ", 1.0f);
        }
        else if (moveinput.z < -0.01f)
        {
            anim.SetFloat("MoveX", 1.0f);
            anim.SetFloat("MoveZ", 1.0f);
        }

        else
        {
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveZ", 0);
           
        }

        moveinput.y += Physics.gravity.y * gravity * Time.deltaTime;

        character.Move(moveinput * Time.deltaTime);
        print(moveinput.x);
        //camera rotation using mouseinput
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSenstivity;
        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
          
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        if (health <= 0)
        {
            SceneManager.LoadScene(6);

        }
        if (time >= 30.0f)
        {
            
                //Instantiate(key, transform.position, Quaternion.identity);
                hintText.text = "Get the key";
            KeyEffect.SetActive(true);
            if (Input.GetKeyDown(KeyCode.K))
                {

                SceneManager.LoadScene(7);
            }
           
        }


    }


    public void playerhealth(float damage)
    {
        health = health - damage;
        healthText.text = "Health: " + Mathf.RoundToInt(health);
    }
    public void noOfDeath(int value)
    {
        enemydeathCount = enemydeathCount + value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            SceneManager.LoadScene(7);
        }
    }
   

}
