using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIControllers : MonoBehaviour
{
        [SerializeField] GameObject gameOverScreen;
    [SerializeField] PlayerControllers Player
    ;
      public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
     
       
    }
   public void GameRestart()
    {
        Debug.Log("Restart the game");
        SceneManager.LoadScene("Prototype 3");

    
    }
}
