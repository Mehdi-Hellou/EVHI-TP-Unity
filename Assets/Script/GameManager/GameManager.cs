using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject gameOverPanel;
    public GameObject restartPanel; 

    void Awake()
    {
        gameOverPanel.SetActive(false);
        restartPanel.SetActive(false); 
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverPanel.SetActive(true); 
            // Restart the game 
            Invoke("Restart",2f); 
        }
    }

    void Restart()
    {
        gameOverPanel.SetActive(false);
        restartPanel.SetActive(true); 
    }
}
