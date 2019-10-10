using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject door; 
    Animator anim; 
    void Awake()
    {
        anim = door.GetComponent<Animator> ();
    }
    // Start is called before the first frame update
    void Start()
    {
  
    }

    void OnTriggerEnter(Collider other) 
    { 
        anim.SetBool("open",true); 
    }
    // Update is called once per frame
    void Update()
    {

    }
}
