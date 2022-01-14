using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
      private Vector3 offset;
   
    
    public GameObject Ball;
    void LateUpdate()
    {
        //offset the camera behind the player's position
        transform.position = Ball.transform.position + offset;

    }
}
