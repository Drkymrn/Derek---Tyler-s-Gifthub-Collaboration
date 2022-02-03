using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public int collectedCoins;
    private float speed = 20.0f;
    private float turnSpeed = 45.5f;
    private float horizontalInput;
    private Rigidbody playerRB;
     public bool isOnGround = true;
    public bool gameOver = false;
    private float forwardInput;
    [SerializeField] UIController uiController;
    public float jumpForce;
    private float xRange = 25.0f;
    private float zRange = 25.0f;
    public float RotateSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
         }
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //rotate player
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        //move player forward and backwards based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

         
        //move left to right
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * turnSpeed);

        //keep player inbounds on x axis
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        //keep player inbounds on z axis
        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

    }

        private void OnCollisionEnter(Collision collision)
        {
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
         if (collision.transform.CompareTag("Obstacle"))
        {
            uiController.ShowGameOverScreen();
        }
        }
         private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable")) {
            collectedCoins++;
            
            Destroy(collision.gameObject);
        }
    }
}
