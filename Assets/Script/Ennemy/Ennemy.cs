using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent; 
    public Transform target; 
    public Transform target2; 
    public float closeDistance = 5.0f;
    
    Transform ennemy;

    Target hpEnnemy; 
 
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

        Vector3 offset = ennemy.position - target.position; 
        float sqrLen = offset.sqrMagnitude;  // The distance between the ennemy and the first target

        Vector3 offset2 = ennemy.position - target2.position;
        float sqrLen2 = offset2.sqrMagnitude;   // The distance between the ennemy and the second target

        // if the ennemy is close enoug to the second target in front of the door 
        if(sqrLen2 < closeDistance * closeDistance) 
        {
            agent.SetDestination(target.position); 
            anim.SetBool("move", true); 
        }
        // if the ennemy is close enoug to the first target 
        else if(sqrLen < closeDistance * closeDistance)
        {
            agent.SetDestination(target2.position); 
            anim.SetBool("move", true);
        }
        

    }

    void OnTriggerEnter(Collider other)
    {

         
        if(other.gameObject.name == "Bullet(Clone)")
        {

            // Take Damage from
            hpEnnemy.TakeDamage(10.0f);
            Destroy(other.gameObject); 
        }
    }


}
