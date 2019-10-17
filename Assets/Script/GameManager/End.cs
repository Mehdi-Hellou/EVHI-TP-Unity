using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class End : MonoBehaviour
{
    public GameObject endPanel; 
    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetSceneByName("Niveau 5") == SceneManager.GetActiveScene())
        {
            endPanel.SetActive(false);
        }
        
    }

    public void Win()
    {
        endPanel.SetActive(true);
        Player player = FindObjectOfType<Player>();

        player.GetComponent<CharacterController>().enabled = false;
        Animator animPlayer = player.GetComponent<Animator>(); 


        Invoke("Quit", 5.0f); 
    }

    void Quit()
    {
        Application.Quit(); 
    }
}
