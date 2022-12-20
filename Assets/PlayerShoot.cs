using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;

    public bool isShooting;

    public Transform shootPos;
    public GameObject bullet;

    public ParticleSystem smoke;
    public ParticleSystem MuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isShooting)
        {
            StartCoroutine(Shoot());
           EnitSmoke();
           EnitMuzzleFlash();
        }   
     
    }
        


    private void EnitSmoke(){
        smoke.Play();
    }
 private void EnitMuzzleFlash(){
        MuzzleFlash.Play();
    }
        
       
    
    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        
        
        
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
    
    
    
}
    