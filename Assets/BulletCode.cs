using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{

    float timer = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void update()
    {   
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }



    }
    // Update is called once per frame
    private void OnTriggeerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            {
               Destroy(this.gameObject); // EI TOIMI GROUNDIIN, ZOMBI TOIMII
            }
    
        
    }   

}
