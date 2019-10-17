using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Animator anim;
    public float speed;
    public float rotSpeed;
    public float gravity;
    public float jumpspeed; 

    float rot = 0f; 
    Vector3 moveDir = Vector3.zero;

    CharacterController controller; 
    public static float healthAmount;

    //the position of the character in the beginning
    static Vector3 startPosition; 

    // Float to know if the character is falling 
    private float velY; 

    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    float bossAttackRate = 1.5f;
    private float bossLastAttack = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 2;
        controller = GetComponent<CharacterController>(); 
        anim = GetComponent<Animator>();
        startPosition = GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
        GetInput();
        velY = controller.transform.position.y;
        //If the player falling 
        if(velY<-10)
        {
            controller.transform.position = startPosition;
            GetComponent<TargetPlayer>().TakeDamage(1.0f);  
        }
    }

    void Movement()
    {
        
    	
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S))
        {
            if (anim.GetBool("attacking") == true)
            {
                return;
            }
            else if (anim.GetBool("attacking") == false)
            {
                anim.SetBool("running", true);
                anim.SetInteger("condition", 1);

                moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;

            }
        }
        else if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("running", false);
            anim.SetInteger("condition", 0);

            moveDir = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (anim.GetBool("attacking") == true)
            {
                return;
            }
            else if (anim.GetBool("attacking") == false)
                moveDir.y = jumpspeed; 
        }

                       
    	
        

    	rot += Input.GetAxis("Horizontal")* rotSpeed * Time.deltaTime;
    	transform.eulerAngles = new Vector3( 0, rot, 0);

    	moveDir.y -= gravity * Time.deltaTime;
    	controller.Move(moveDir * Time.deltaTime); 
    }

    void GetInput()
    {

        if(Input.GetKey(KeyCode.A))
        {
              
            if (anim.GetBool("running") == true)
            {
                anim.SetBool("running",false); 
                anim.SetInteger("condition", 0); 
            }

            if(anim.GetBool("running") == false)
            {
                Attacking();
            }     
        }
    }

    void Attacking()
    { 
        
        StartCoroutine (AttackRoutine()); 
    }

    IEnumerator AttackRoutine()
    {
        anim.SetBool("attacking",true); 
        anim.SetInteger("condition",2);
        yield return new WaitForSeconds (1); 
        anim.SetInteger("condition",0); 
        anim.SetBool("attacking",false); 
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Contains("Monster"))
        {
            if (Time.time > bossAttackRate + bossLastAttack)
            {
                GetComponent<TargetPlayer>().TakeDamage(2.0f);
                bossLastAttack = Time.time; 
            }
        }
        else if (other.gameObject.name.Contains("Ennemy"))
        {
            if (Time.time > bossAttackRate + bossLastAttack)
            {
                GetComponent<TargetPlayer>().TakeDamage(0.5f);
                bossLastAttack = Time.time;
            }
        }
    }

}
