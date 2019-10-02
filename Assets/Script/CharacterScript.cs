using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Animator anim;
    public float speed;
    public float rotSpeed;
    public float gravity;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller; 

    // Start is called before the first frame update
    void Start()
    {
    	controller = GetComponent<CharacterController>(); 
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Movement(); 
        Attacking(); 
        
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("running",true);
            anim.SetInteger("condition",1);
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        }

        if(Input.GetKey(KeyCode.S))
        {
            anim.SetBool("running",true);
            anim.SetInteger("condition",1);
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            
        }

        if(Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("running",false);
            anim.SetInteger("condition",0);
            transform.Rotate(Vector3.up, - rotSpeed * Time.deltaTime);
            
        }

        if(Input.GetKey(KeyCode.D))
        {
            anim.SetBool("running",false);
            anim.SetInteger("condition",0);
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.None))
        {
            anim.SetBool("running",false);
            anim.SetInteger("condition",0);
        }
    }

    void GetInput()
    {
        
    }
    void Attacking()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("attacking",true); 
            anim.SetInteger("condition",2); 
        }
    }
}
