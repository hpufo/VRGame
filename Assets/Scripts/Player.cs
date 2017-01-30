using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform firePoint;                 //Where I am going to fire lasers from
    public GameObject laserPrefab;
    public AudioSource laserSound;

    private float speed = 50;
    private CharacterController controller;
    private float laserJumpForce = 1000;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
    }

    void ProcessInput()
    {
        PlayerMovement();
        // 0 = left click on mouse or tap on gear VR
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            GameObject laser = GameObject.Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            laserSound.Play();
            //Jump code
            //localEulerAngles gets the rotation as seen in the editor. Aka where it is in the world
            if (laser.transform.localEulerAngles.x > 80 && laser.transform.localEulerAngles.x < 100)    //If the player is shooting below them propel yourself up.
            {
                //Jump
                //rigidbody.AddForce(new Vector3(0, laserJumpForce, 0));
            }//*/
        }
    }

    void PlayerMovement()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetAxis("Mouse Y") > 0)
        {
            movement += transform.TransformDirection(Vector3.forward);
        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            movement += transform.TransformDirection(Vector3.back);
        }

        if (Input.GetAxis("Mouse X") > 0)
        {
            movement += transform.TransformDirection(Vector3.left);
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            movement += transform.TransformDirection(Vector3.right);
        }
        controller.SimpleMove(Physics.gravity);
        controller.SimpleMove(movement * speed);
    }
}
