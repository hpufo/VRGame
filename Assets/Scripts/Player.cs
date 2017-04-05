using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform firePoint;                 //Where I am going to fire lasers from
    public GameObject laserPrefab;
    public AudioSource laserSound;
    //Character movement
    private float jumpSpeed = 40;
    private float gravity = 20;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchInput;
    }
	
	// Update is called once per frame
	void Update () {
        //applying gravity and making the player move with all the applied forces
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void HandleTouchInput(object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        //Tap Also processed as a mouse click
        if(touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
        {
            GameObject laser = GameObject.Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            laserSound.Play();
            //If the player shoots down propel yourself up
            if (laser.transform.localEulerAngles.x > 80 && laser.transform.localEulerAngles.x < 100 && controller.isGrounded)
            {
                //jump code
                moveDirection.y = jumpSpeed;
                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);
            }
        }
    }
}
