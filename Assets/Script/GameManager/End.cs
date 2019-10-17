using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject endPanel; 
    // Start is called before the first frame update
    void Awake()
    {
        endPanel.SetActive(false); 
    }

    public void Win()
    {
        endPanel.SetActive(true); 
    }
}
