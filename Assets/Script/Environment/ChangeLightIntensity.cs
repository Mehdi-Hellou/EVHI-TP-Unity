using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightIntensity : MonoBehaviour
{
    // Interpolate light color between two colors back and forth
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;

    Light lt;
    public GameObject Light; 

    void Start()
    {
        lt = Light.GetComponent<Light>();
    }

    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        // set light intensity
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.intensity = Mathf.Lerp(lt.intensity, 3.0f, t);
    }

    
}
