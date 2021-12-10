using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Kyle : MonoBehaviour
{
    public float radius = 20.0F;
    public float power = 10.0F;

    public GameObject kyle;
    public Camera mainCamera;
    public AudioClip damageClip;


    private Animator animation_controller;
    private CharacterController character_controller;

    private float verticalVelocity;
    private bool groundedPlayer;
    // private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;


    void Start()
    {
        animation_controller = kyle.GetComponent<Animator>();
        character_controller = kyle.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    float speed = 0f;

    void FixedUpdate()
    {

        // Update Camera Position
        mainCamera.transform.position = kyle.transform.position - kyle.transform.forward * 4;
        mainCamera.transform.LookAt(kyle.transform.position);
        mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, mainCamera.transform.position.y + 1.5f, mainCamera.transform.position.z);

        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // character_controller.Move(move * Time.deltaTime * playerSpeed);

        animation_controller.SetBool("Grounded", character_controller.isGrounded);
        if (!character_controller.isGrounded) {
            Debug.Log("!!!");
        }

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !animation_controller.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
            kyle.transform.Rotate(0, -50f * Time.fixedDeltaTime, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !animation_controller.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
            kyle.transform.Rotate(0, 50f * Time.fixedDeltaTime, 0);
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !animation_controller.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                if (speed >= 0.09f) {
                    speed -= 0.01f;
                } else {
                    speed += 0.01f;
                }
            } else {
                if (speed >= 0.05f) {
                    speed -= 0.01f;
                } else {
                    speed += 0.01f;
                }
            }
            character_controller.Move(kyle.transform.forward * speed * Time.fixedDeltaTime);
        } else if (speed > 0) {
            speed -= 0.01f;
        } else {
            speed = 0;
        }

        animation_controller.SetFloat("Speed", speed);

        if (animation_controller.GetCurrentAnimatorStateInfo(0).IsName("Locomotion")) {
            character_controller.Move(kyle.transform.forward * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            verticalVelocity += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animation_controller.SetBool("Jump", true);
        } else {
            animation_controller.SetBool("Jump", false);
        }
        
        character_controller.Move(kyle.transform.up * -0.04f * Time.fixedDeltaTime);



        // if (animation_controller.GetCurrentAnimatorStateInfo(0).IsName("Locomotion")) {
        //     float currVelocity = character_controller.velocity.magnitude;
        //     if (currVelocity > 2) {
        //         character_controller.Move(kyle.transform.forward * 2);
        //     } else {
        //         character_controller.Move(kyle.transform.forward * (currVelocity + 0.1f));
        //     }
        // }




        // Changes the height position of the player..


        // character_controller.Move
        // verticalVelocity -= gravityValue * Time.deltaTime;
        // character_controller.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
        // animation_controller.SetFloat("Speed", Mathf.Abs(character_controller.velocity.magnitude));
    }

    void OnCollisionEnter(Collision c)
    {

     float y_val = transform.position.y;
 

     if (c.gameObject.tag == "Flag")
     {
        Game.currentLevel += 1;
        kyle.GetComponent<Rigidbody>().velocity = Vector3.zero;
     }

    if (c.gameObject.tag == "Victory")
    {
        SceneManager.LoadScene("WinScreen");
        Game.currentLevel = 0;
    }

     // If the object we hit is the enemy
     if (c.gameObject.tag == "enemy_doll")
     {
        Vector3 target_pos = c.contacts[0].point;
        Vector3 dir = -(target_pos - transform.position);
        Game game = FindObjectsOfType<Game>()[0];
        game.health--;
        AudioSource.PlayClipAtPoint(damageClip, kyle.transform.position);

     }
     else if (c.gameObject.tag == "enemy_train")
     {
        Game game = FindObjectsOfType<Game>()[0];
        AudioSource.PlayClipAtPoint(damageClip, kyle.transform.position);
        game.health -= game.health;

     }
 }
}
