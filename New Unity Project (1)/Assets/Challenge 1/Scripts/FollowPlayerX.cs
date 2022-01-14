using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    
    void LateUpdate()
    {
        //offset the camera behind the player's position
        transform.position = plane.transform.position + offset;
    }
}
