using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class TargetBoss : MonoBehaviour
{
    public static float health = 7.0f;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash


    bool damaged;
    Animator anim; 
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ; 
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
                    this.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color, new Color(1.0f, 1.0f, 1.0f, 1.0f)
                    , flashSpeed * Time.deltaTime);
            }
        }
        damaged = false; 
    }

    public void TakeDamage(float amount)
    {
        damaged = true; 
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        this.GetComponent<NavMeshAgent>().updatePosition = false;
        this.GetComponent<NavMeshAgent>().updateRotation = false;
        if (anim.GetBool("attacking") == true)
        {
            anim.SetBool("attacking", false);
            anim.SetInteger("condition", 0);
        }

        if (anim.GetBool("walk") == true)
        {
            anim.SetBool("walk", false);
            anim.SetInteger("condition", 0);
        }

        anim.SetInteger("condition", 3);
        anim.SetBool("dead", true);

        FindObjectOfType<End>().Win(); 
    }
}
