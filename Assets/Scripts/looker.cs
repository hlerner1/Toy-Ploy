using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looker : MonoBehaviour
{
     	
    public GameObject guard;
    public string enemy_type;
    public bool in_range;

    private float reset = 0.1f;
    private bool movingDown;
    private Animator animation_controller;
    private CharacterController character_controller;

    // Start is called before the first frame update
    void Start()
    {
        in_range = false;
        if (enemy_type.Equals("train")){
            guard.GetComponent<MeshCollider>().enabled = true;
        }
        else{
            guard.GetComponent<CapsuleCollider>().enabled = true;
            animation_controller = guard.GetComponent<Animator>();
        }
        // character_controller = guard.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (movingDown == false)
        //     transform.position -= new Vector3(0, 0, 0.1f);
        // else
        //     transform.position += new Vector3(0, 0, 0.1f);
        // if (transform.position.z > 10)
        //     movingDown = false;
        // else if (transform.position.z < -10)
        //     movingDown = true;
        reset -= Time.deltaTime;
        if (reset < 0)
        {
            guard.GetComponent<Guard>().enabled = false;
            // GetComponent<MeshCollider>().enabled = true;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("collision!");
            guard.GetComponent<Guard>().enabled = true;
            // GetComponent<MeshCollider>().enabled = false;
            
            reset = 0.1f;
            if (enemy_type.Equals("train")){
                in_range = true;
            }
            else{
                animation_controller.SetFloat("Speed", .1f);
                animation_controller.SetBool("targeting", true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        // guard.GetComponent<Guard>().enabled = false;
        if (enemy_type.Equals("train")){
            in_range = false;
        }
        else{
            animation_controller.SetFloat("Speed", 0f);
        }
    }
    

}
