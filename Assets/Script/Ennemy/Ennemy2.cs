using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy2 : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    public Transform player;

    Transform ennemy;
    Target hpEnnemy;   // script when the ennemy take a damage
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ennemy = GetComponent<Transform>();

        hpEnnemy = GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {


        if(player.position.z > 8.0f)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
            anim.SetBool("move", true); 
        }

    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name == "Bullet(Clone)")
        {

            // Take Damage from
            hpEnnemy.TakeDamage(10.0f);
            Destroy(other.gameObject);
        }
    }

    void OnCollisionExit(Collision collision)
    {

    }
}
