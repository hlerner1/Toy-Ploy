using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyle : MonoBehaviour
{
    public float radius = 20.0F;
    public float power = 10.0F;

    public GameObject kyle;
    public AudioClip damageClip;

    // public health h;
    private GameObject train;
    // Start is called before the first frame update
    void Start()
    {
        train = GameObject.Find("TutorialTrain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision c)
 {
     // force is how forcefully we will push the player away from the enemy.
    //  float force = 5;
     float y_val = transform.position.y;
 

     if (c.gameObject.tag == "Flag")
     {
        Game.currentLevel += 1;
     }

     // If the object we hit is the enemy
     if (c.gameObject.tag == "enemy_train")
     {
        Vector3 target_pos = c.contacts[0].point;
        
        // while (Vector3.Distance(transform.position, target_pos) > 0.1f){
            Vector3 dir = -(target_pos - transform.position);
            // Debug.Log(dir[0] + " " + dir[1] + " " + dir[2]);
            Game game = FindObjectsOfType<Game>()[0];
            game.health--;
            // Vector3 v=dir;
            // Vector3 direction = v;
            // if (v.magnitude != 0){
            //     direction = v / v.magnitude; 
            // }
            // float time_step = force * Time.deltaTime;
            // transform.position += direction * time_step;
            // float y_val = transform.position.y;
            // Vector3 t_vec = new Vector3(transform.position.x, y_val, transform.position.z);
            // transform.position = t_vec;
        // }

        AudioSource.PlayClipAtPoint(damageClip, kyle.transform.position);

     }
 }
}
