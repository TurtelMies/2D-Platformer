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

    // Update is called once per frame
    void Update()
    {

        //if (checkTrigger ){}
        
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            checkTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            checkTrigger = false;
        }
    }

        

}

