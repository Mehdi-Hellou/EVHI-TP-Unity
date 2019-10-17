using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBoss : MonoBehaviour
{
    Vector3 localScale;

    float hpBossFull; 
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        hpBossFull = TargetBoss.health; 
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = TargetBoss.health / hpBossFull;
        transform.localScale = localScale;
    }
}
