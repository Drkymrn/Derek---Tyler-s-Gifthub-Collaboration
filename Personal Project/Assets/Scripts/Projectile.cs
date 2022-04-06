using UnityEngine;

/// <summary>
/// Handle the projectile launched by the player to fix the robots.
/// </summary>
public class Projectile : MonoBehaviour
{
   private Rigidbody projectileRB;
   public GameObject Enemy;
   public float speed;
    
    void Awake()
    {
        projectileRB= GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        //destroy the projectile when it reach a distance of 1000.0f from the origin
       if(transform.position.magnitude > 1000.0f)
           Destroy(gameObject);
    }

    //called by the player controller after it instantiate a new projectile to launch it.
    public void Launch(Vector3 direction, float force)
    {
       projectileRB.AddForce(direction * force);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

   void OnTriggerEnter(Collider other)
    {
        //Enemy = other.collider.GetComponent<Enemy>();
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        //if the object we touched wasn't an enemy, just destroy the projectile.
        //if (Enemy != null)
       // {
            //Enemy.Fix();
       // }
        
        Destroy(gameObject);
    }
}
