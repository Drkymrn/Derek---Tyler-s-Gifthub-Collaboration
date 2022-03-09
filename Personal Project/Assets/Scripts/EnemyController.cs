using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
     public float speed = 3.0f;
     int MoveDist = 20;
     int AttackDist = 5;
     GameObject player;
    // Start is called before the first frame update
    void Start()
    {
         enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.ransform.position);
        if(Vector3.Distance(transform.poition, player.transform.position) <= MoveDist){
            Vector3 position = Vector3.MoveTowards(transform.position, player,transform.position, speed * Time.deltaTime);
            enemyRb.MovePosition(position);
            if (Vector3.Distance(transform.position, player.transform.position) <= AttackDist)
            {
                //Debug.Log("Attack Distance Achieved!!!");
            }
        
        }
        if (transform.position.y <-10){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
      PlayerController player = other.gameObject.GetComponent<PlayerController>();
      if(player != null)
      {
          player.ChangeHealth(-1);
      }  
    }
}
