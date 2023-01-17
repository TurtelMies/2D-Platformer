using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public float MovementSpeed = 400000;
    public float JumpForce = 5;

    private Rigidbody2D _rigidbody;

    public Animator animator;

    public GameObject Player;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public int helt = 0; 

    public bool stopMoving = false;
    public GameObject PlayerDed;
    public GameObject Shotgun;
    public float pYpos;
    public float pXpos;

    //--------------------------------------------------------------https://www.youtube.com/watch?v=zc8ac_qUXQY ------------- Menu screen
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);  

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        // gameObject.GetComponent<Renderer>().enabled = false;

        //other.GetComponent<BoxCollider>().enabled = false;

        //do turning ?? too much
        
        if (stopMoving == false)
        {
            //recoil
            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) //Voi potkaista ilman ampumista
            {
                _rigidbody.AddForce(new Vector2(-5, 2), ForceMode2D.Impulse);
            }

            //Movement & Jump & Anim. controll
             var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

            animator.SetFloat("Speed", Mathf.Abs(movement)); 

            if (Input.GetKey("w") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

            animator.SetBool("IsJumping", true);
            }
            if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
             animator.SetBool("IsJumping", false);
            }
        
            if (Input.GetButtonDown("Jump")){
                
            }

        }
        
       
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

     void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "Zombie")
        {
            TakeDamage(20);
            helt++;
            _rigidbody.AddForce(new Vector2(-4, 2), ForceMode2D.Impulse);
            if (helt == 5)
            {
                stopMoving = true;
                pXpos = this. transform. position. x;
                pYpos = this. transform. position. y;
                gameObject.GetComponent<Renderer>().enabled = false;
                StartCoroutine(DedPlayerSpawn());
                StartCoroutine(ShotgunSpawn());
               
                
            }
        }
        if (collision.gameObject.tag == "Lava")
        {
            TakeDamage(100);
            stopMoving = true;
             gameObject.GetComponent<Renderer>().enabled = false;
        }

        }   

        IEnumerator DedPlayerSpawn() 
        {
            Instantiate(PlayerDed,new Vector2 (pXpos,pYpos), Quaternion.identity);
            return null;
        }

        IEnumerator ShotgunSpawn() 
        {
            Instantiate(Shotgun,new Vector2 (pXpos,pYpos), Quaternion.identity);
            return null;
        }


}
 