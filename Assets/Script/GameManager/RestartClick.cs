using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartClick : MonoBehaviour
{
    public void YesClick()
    {
        TargetPlayer.health = TargetPlayer.healthMax; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }
    public void NoClick()
    {
        Application.Quit();
    }
}
