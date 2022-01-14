using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
         public float CollectedScore;
  
   private int score = 0;
    // Start is called before the first frame update
    void OnCollisonEnter(Collision Ball)
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("No score"))
            {
            Debug.Log(score);
            score = score + 1;
            CollectedScore++;
            }
           
    }
}