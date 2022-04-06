using UnityEngine;

/// <summary>
/// Will handle giving health to the character when they enter the trigger.
/// </summary>
public class HealthCollectible : MonoBehaviour 
{
    [SerializeField] PlayerController player;
    public GameObject Player;
    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.health < player.maxHealth)
            {
                player.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
