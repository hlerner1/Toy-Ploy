using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looker : MonoBehaviour
{
     	
    public GameObject guard;
    private float reset = 0.1f;
    private bool movingDown;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("collision!");
        if (other.gameObject.tag == "Player") {
            Debug.Log("player");
            guard.GetComponent<Guard>().enabled = true;
            // GetComponent<MeshCollider>().enabled = false;
            guard.GetComponent<MeshCollider>().enabled = true;
            reset = 0.1f;
        }
    }

}
