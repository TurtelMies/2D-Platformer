using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Zombie : MonoBehaviour
{
    private bool checkTrigger;
    public float speed;
    public Transform target;
  





    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }



 void OnTriggerEnter2D(Collider2D collision)
 {
 if (collision.gameObject.CompareTag("Bullet"))
    {
        Destroy(this.gameObject);
    }   

 }


    // Update is called once per frame
    void Update()
    {

        //if (checkTrigger ){}
        
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


    }

   
        

}

