using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    TargetPlayer player;

    float timeTaken; 
    float timeEffect = 20.0f; 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<TargetPlayer>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (TargetPlayer.invisible && Time.time-timeTaken > timeEffect)
        {
            TargetPlayer.invisible = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false; 
            timeTaken = Time.time; 
            TargetPlayer.invisible = true;
            
        }
    }


}
