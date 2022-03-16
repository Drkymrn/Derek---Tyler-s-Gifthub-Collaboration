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
    //Added health variables here
    public int maxHealth = 5;
    public int health {get { return currentHealth;}}
    int currentHealth = 5;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    public Transform respawnPosition;

    //Added projectile variable
    public GameObject projectilePrefab;
    public ParticleSystem hitParticle;
    Vector3 lookDirection = new Vector3(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Debug.Log("Health: " + currentHealth + "/" + maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.E))
        {
          LaunchProjectile();
        }
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
  
    }         // ===================== HEALTH ==================
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        { 
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
          

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        if(currentHealth == 0)
            Respawn();
        
        //UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);
    }
      void Respawn()
    {
        ChangeHealth(maxHealth);
        transform.position = respawnPosition.position;
    }
      // =============== PROJECTICLE ========================
    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, playerRB.position + Vector3.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        
      
    }
}
