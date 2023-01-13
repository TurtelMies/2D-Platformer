using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    private void OnTriggeerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            {
               Destroy(gameObject); // EI TOIMI GROUNDIIN, ZOMBI TOIMII
            }
    
        
    }   

}
