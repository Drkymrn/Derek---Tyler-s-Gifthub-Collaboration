using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < -10)
       {
           Destroy(gameObject);
       } 
    }
    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Enemy")
       {
           Destroy(other.gameObject);
       } 
       Destroy(gameObject);
    }
}
