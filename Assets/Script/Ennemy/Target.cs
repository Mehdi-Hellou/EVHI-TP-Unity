using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50.0f;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash

    private SkinnedMeshRenderer[] origineColor;
    public static bool damaged; 
    // Start is called before the first frame update
    void Awake()
    {
        origineColor = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            for (int i = 0; i < this.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
            {
                this.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color = flashColour;
            }
        }
        else
        {
            for (int i = 0; i < this.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
            {
                this.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color = Color.Lerp(
                    this.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color, new Color(1.0f,1.0f,1.0f,1.0f)
                    , flashSpeed * Time.deltaTime);
            }
        }
        damaged = false; 
    }

    public void TakeDamage(float amount)
    {
        damaged = true; 
        health -= amount;
        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }
}
