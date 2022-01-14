using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] Text Score;
    [SerializeField] GameObject gameOverScreen;
  
    [SerializeField]  Score Ball;
  
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;
   public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        sky.SetActive(false);
        //distanceTraveled.text = Ball.distanceTraveled.ToString
  
        Score.text = "" + Ball.CollectedScore;
    
    }
   public void GameRestart()
    {
        Debug.Log("Restart the game");
        SceneManager.LoadScene("Pinball Game");
    }
}
