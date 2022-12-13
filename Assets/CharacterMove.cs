using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public float MovementSpeed = 400000;
    public float JumpForce = 5;

    private Rigidbody2D _rigidbody;

    public Animator animator;

 


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);  
    }

    // Update is called once per frame
    void Update()
    {

        
        
    //do turning
        
        
 //recoil
if (Input.GetButtonDown("Fire1") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(-5, 2), ForceMode2D.Impulse);
        }

//Movement & Jump & Anim. controll
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

    animator.SetFloat("Speed", Mathf.Abs(movement)); 

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

            animator.SetBool("IsJumping", true);
        }
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
             animator.SetBool("IsJumping", false);
        }
    }

        
}
 