using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip doubleJump;
    [SerializeField] AudioClip gameOverHit;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;
    [SerializeField] AudioClip doubleJumpPowerUp;
    [SerializeField] AudioClip shieldPowerUp;
    [SerializeField] AudioClip shieldBreak;
    public void PlaySFX(string clipToPlay)
    {
        switch (clipToPlay) {
            case "Coin":
                audioSource.clip = coin;
                break;
            case "Jump":
                    audioSource.clip = jump;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJump;
                break;
            case "Land":
                audioSource.clip = land; 
                break;
            case "DoubleJumpPowerUp":
                audioSource.clip = doubleJumpPowerUp;
                break;
            case "ShieldPowerUp":
                audioSource.clip = shieldPowerUp;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverHit;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreak;
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
