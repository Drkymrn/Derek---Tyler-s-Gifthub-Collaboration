using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
      public float CollectedScore;
     [SerializeField] UIController uiController;
      private Rigidbody ball;
      public bool gameOver = false;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.AddForce(Vector3.forward * force);
           
        }
       
   
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (!collision.gameObject.CompareTag("No score"))
        { Vector3 colDirection = collision.contacts[0].point - transform.position;
            CollectedScore++;
        colDirection = -colDirection.normalized;
            ball.AddForce(colDirection * 1200);
        }
   if (collision.transform.CompareTag("DeathBox"))
        {
            uiController.ShowGameOverScreen();
        
     
    }
    }
      
         
}
