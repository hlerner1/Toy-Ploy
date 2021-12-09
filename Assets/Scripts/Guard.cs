using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public GameObject player;
    public GameObject looker_game_obj;
    public float guard_speed;

    private NavMeshAgent navmesh;
    private Animator animation_controller;
    private CharacterController character_controller;
    private looker looker_val;


    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        looker_val = looker_game_obj.GetComponent<looker>();
        // if (GetComponent<looker>().enemy_type.Equals("train")){
        //     animation_controller = GetComponent<Animator>();
        //     character_controller = GetComponent<CharacterController>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (looker_val.in_range){
            navmesh.destination = player.transform.position;
            navmesh.speed = guard_speed;
        }
        else{
            navmesh.destination = transform.position;
            navmesh.speed = 0f;
        }

    }
}
