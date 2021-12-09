using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent navmesh;
    private Animator animation_controller;
    private CharacterController character_controller;


    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        animation_controller = GetComponent<Animator>();
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animation_controller.GetFloat("Speed") > 0f){
            navmesh.destination = player.transform.position;
        }
        else{
            navmesh.destination = transform.position;
        }

    }
}
