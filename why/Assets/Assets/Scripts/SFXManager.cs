using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
        [SerializeField] AudioSource audioSource;
   
    
    [SerializeField] AudioClip gameOverHit;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;
        public void PlaySFX(string clipToPlay)
    {
        switch (clipToPlay) {
           
            case "Jump":
                    audioSource.clip = jump;
                break;
            
            case "Land":
                audioSource.clip = land;
                break;
          
           
            case "GameOverHit":
                audioSource.clip = gameOverHit;
                break;
          
           
        }
        /*if (clipToPlay == "Coin")
        {
            audioSource.clip = coin;
        }
        if (clipToPlay == "DoubleJump") {
            audioSource.clip = doubleJump;
        }
        if (clipToPlay == "GameOverHit") {
            audioSource.clip = gameOverHit;
        }
        if (clipToPlay == "Jump") {
            audioSource.clip = jump;
        }
        if (clipToPlay == "Land") {
            audioSource.clip = land;
        }
        if (clipToPlay == "DoubleJumpPowerUp") {
            audioSource.clip = doubleJumpPowerUp;
        }
        if (clipToPlay == "ShieldPowerUp") {
            audioSource.clip = shieldPowerUp;

        }
        if (clipToPlay == "ShieldBreak") {
            audioSource.clip = shieldBreak;
        }*/
        audioSource.Play();
    }


}
