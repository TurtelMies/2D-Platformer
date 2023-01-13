using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Zombie : MonoBehaviour
{
     private bool checkTrigger;
     public float speed;
     public Transform target;

     public GameObject head;
     public GameObject zombiebody;
  
     public float horizontalInput;
     public float verticalInput;

     public float Xpos;
     public float Ypos;

     private Rigidbody2D _rigidbody;

     

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }



 void OnTriggerEnter2D(Collider2D collision)
 {
 if (collision.gameObject.CompareTag("Bullet"))
    {
       Xpos = this. transform. position. x;
     Ypos = this. transform. position. y;
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
      StartCoroutine(spawn());
    }   

 }


    // Update is called once per frame
    void Update()
    {

        //if (checkTrigger ){}
        
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    IEnumerator spawn() //-------------------- ADD FORCE, PICKUPS
    {
       Instantiate(head,new Vector2 (Xpos,Ypos + 1), Quaternion.identity);
       Instantiate(zombiebody,new Vector2 (Xpos,Ypos), Quaternion.identity);
        return null;
    }


}

