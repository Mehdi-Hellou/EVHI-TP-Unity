using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    float healthGiven = 2.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            TargetPlayer.healed = true; 
            if (TargetPlayer.health + healthGiven > TargetPlayer.healthMax)
            {
                TargetPlayer.health = TargetPlayer.healthMax;
            }
            else
            {
                TargetPlayer.health += healthGiven;
            }
            Invoke("NoHealed", 2.0f); 
             
        }
    }

    // Function to desactivate the color blue given when the player touch a heart

    void NoHealed()
    {
        Destroy(gameObject);
        TargetPlayer.healed = false; 
    }
}
