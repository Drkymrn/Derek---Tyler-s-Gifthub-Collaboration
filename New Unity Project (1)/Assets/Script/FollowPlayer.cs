using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Vector3 offset = new Vector3(0, 5, -7);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        //offset the camera behind the player's position
        transform.position = player.transform.position + offset;
    }
}
