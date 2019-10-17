using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    public Transform player;

    private SkinnedMeshRenderer[] origineColor;
    Transform boss;
    TargetBoss hpBoss;   // script when the ennemy take a damage

    bool engagerCombat = false;  // if the player is close of the ennemy, he attacking the player 

    float attackRate = 1.5f;
    private float lastAttack = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        boss = GetComponent<Transform>();

        hpBoss = GetComponent<TargetBoss>();
        origineColor = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, boss.position);

        if (distance <20.0)
            engagerCombat = true;

        if (engagerCombat)
        {
            agent.transform.LookAt(player.transform);
            if (Mathf.Abs(distance - 0.5f) < 5)
            {
                if (anim.GetBool("walk") == true)
                {
                    anim.SetBool("walk", false);
                    anim.SetInteger("condition", 0);
                }

                Attacking();
 
            }
            else
            {
                if (anim.GetBool("attacking") == true)
                {
                    anim.SetBool("attacking", false);
                    anim.SetInteger("Condition", 0); 
                   
                }
               
                Movement();
                
            }
        }

    }

    void Movement()
    {     
        
        anim.SetBool("walk", true);
        anim.SetInteger("condition", 1);
        agent.destination = player.transform.position + new Vector3(3.5f, 0, 3.5f);
        
    }

    void Attacking()
    {
        if (Time.time > attackRate + lastAttack)
        {
            anim.SetBool("attacking", true);
            anim.SetInteger("condition", 2);
            lastAttack = Time.time;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Bullet(Clone)")
        {

            // Take Damage from
            hpBoss.TakeDamage(1.0f);
            Destroy(other.gameObject);
        }

   
    }
}
