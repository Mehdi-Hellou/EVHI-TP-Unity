using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Click : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    public static float healthAmount;

    Transform position;

    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    private float epsilon = 0.5f; 
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 2;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && anim.GetBool("attacking") == false)
            {
                agent.SetDestination(hit.point);
            }

        }

        if (agent.remainingDistance>agent.stoppingDistance + epsilon)
        {
            if (anim.GetBool("attacking") == true)
            {
                anim.SetBool("running", false);
                anim.SetInteger("condition", 0);
                return;
            }
            else if (anim.GetBool("attacking") == false)
            {
                anim.SetBool("running", true);
                anim.SetInteger("condition", 1);

            }
        }

        else
        {
            anim.SetBool("running", false);
            anim.SetInteger("condition", 0);
        }


    }

    void GetInput()
    {

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log(hit.collider.gameObject.name); 
                if (hit.collider.gameObject.name == "Ennemy")
                {
                    position.LookAt(hit.transform);
                    
                }

                if (anim.GetBool("running") == true)
                {
                    agent.ResetPath();
                    agent.isStopped = true;
                    anim.SetBool("running", false);
                    anim.SetInteger("condition", 0);
                }

                if (anim.GetBool("running") == false)
                {
                    Attacking();
                }


            }
        }
    }

    void Attacking()
    {

        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        anim.SetBool("attacking", true);
        anim.SetInteger("condition", 2);
        AppearBullet();
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0);
        anim.SetBool("attacking", false);
    }

    // To make appear a bullet 
    void AppearBullet()
    {
        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

        //Retrieve the collider component from the instantiated Bullet and control it.
        Collider Temporary_collider;
        Temporary_collider = Temporary_Bullet_Handler.GetComponent<Collider>();

        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        Destroy(Temporary_Bullet_Handler, 3.0f);

    }


}
