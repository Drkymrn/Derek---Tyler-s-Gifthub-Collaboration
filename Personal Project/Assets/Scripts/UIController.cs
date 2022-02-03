using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text coinsCollected;

[SerializeField] GameObject gameOverScreen;
    
    [SerializeField] PlayerController player;
    
   public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        
        //distanceTraveled.text = player.distanceTraveled.ToString
         coinsCollected.text = "" + player.collectedCoins;
        
    }
   public void GameRestart()
    {
        Debug.Log("Restart the game");
        SceneManager.LoadScene("My Game");
    }

}
