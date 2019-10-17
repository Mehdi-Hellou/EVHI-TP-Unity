using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color origineColor;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash

    // Start is called before the first frame update
    void Awake()
    {
        origineColor = GetComponent<SkinnedMeshRenderer>().material.color; 
    }

    public void ChangeColor_Body(bool damaged)
    {
        if (damaged)
        {
            this.GetComponent<SkinnedMeshRenderer>().material.color = flashColour;
        }
        else
        {
            this.GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(flashColour, origineColor, flashSpeed * Time.deltaTime);
        }
    }
}
