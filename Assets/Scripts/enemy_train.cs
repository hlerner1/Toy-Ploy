using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_train : MonoBehaviour
{
    private float train_speed = 2.0f;
    bool flag = false;
    bool flipped = false;
    Vector3 target_pos_1 = new Vector3(-820.89f, 73.33f, 495.9f);
    Vector3 target_pos_2 = new Vector3(-838.16f, 73.33f, 493.52f);
    // private GameObject fps_player_obj;
    // Start is called before the first frame update
    void Start()
    {
        // fps_player_obj = GameObject.FindGameObjectWithTag("enemy_train");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_pos = target_pos_1;
        if (flag){
            target_pos = target_pos_2;
        }
        if (Vector3.Distance(transform.position, target_pos) <= 0.1f && !flipped){
            flag = !flag;
            flipped = true;
        }
        if (Vector3.Distance(transform.position, target_pos) > 1.0f && flipped){
            flipped = false;
        }

        Vector3 v=(target_pos - transform.position);
        Vector3 direction = v;
        if (v.magnitude != 0){
            direction = v / v.magnitude; 
        }
        float time_step = train_speed * Time.deltaTime;
        transform.position += direction * time_step;
        float y_val = transform.position.y;
        // if (y_val >= 2.5f){
        //     y_val = 1.0f;
        // }
        Vector3 t_vec = new Vector3(transform.position.x, y_val, transform.position.z);
        transform.position = t_vec;
    }
}
