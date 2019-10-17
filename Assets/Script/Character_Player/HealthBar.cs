using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    

    Vector3 localScale;  // the scale that will change when the player take damages in order to see the impact on the scale of the HP bar
    Vector3 beginscale; // the scale for the begin, when the player has all his hp
    
    // Start is called before the first frame update
    void Start()
    { 
        localScale = transform.localScale;
        beginscale = transform.localScale; 
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetPlayer.health > 0f)
        {
            localScale.x = (TargetPlayer.health/TargetPlayer.healthMax) * beginscale.x;
        }
        else
        {
            localScale.x = 0;
        }

        transform.localScale = localScale; 
    }
}
