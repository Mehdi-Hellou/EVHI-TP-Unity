using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public static float health = 6.0f;
    public static float healthMax = health;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color damageColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash

    Animator anim;
    Player player;
    bool damaged; // boolean to indicate if the player took damages
    public static bool invisible = false; // boolean to know if the player has taken a star 
    public static bool healed = false; // boolean to know if the player has taken a heart
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

        if (damaged)
        {
            for (int i = 0; i < this.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
            {
                player.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color = damageColour;
            }
        }
        else if(invisible)
        {
            for (int i = 0; i < this.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
            {
                player.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color = Color.yellow;
            }
        }
        else if (healed)
        {
            for (int i = 0; i < this.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
            {
                player.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color = Color.green;
            }
        }
        else
        {
            for (int i = 0; i < this.GetComponentsInChildren<SkinnedMeshRenderer>().Length; i++)
            {
                player.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color = Color.Lerp(
                    this.GetComponentsInChildren<SkinnedMeshRenderer>()[i].material.color, new Color(1.0f, 1.0f, 1.0f, 1.0f)
                    , flashSpeed * Time.deltaTime);
            }
        }

        damaged = false;
    }

    public void TakeDamage(float amount)
    {
        if (invisible != true)
        {
            damaged = true;
            health -= amount;
        }
        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.GetComponent<CharacterController>().enabled = false; 
        anim.SetInteger("condition", 3); 
        anim.SetBool("dead", true);
        FindObjectOfType<GameManager>().EndGame(); 
    }
}
