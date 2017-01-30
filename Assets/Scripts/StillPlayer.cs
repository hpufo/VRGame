using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillPlayer : MonoBehaviour {

    public Transform firePoint;                 //Where I am going to fire lasers from
    public GameObject laserPrefab;
    public AudioSource laserSound;

    private new Rigidbody rigidbody;
    private float laserJumpForce = 1000;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        // 0 = left click on mouse or tap on gear VR
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            GameObject laser = GameObject.Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            laserSound.Play();
            //Jump code
            //localEulerAngles gets the rotation as seen in the editor. Aka where it is in the world
            if (laser.transform.localEulerAngles.x > 80 && laser.transform.localEulerAngles.x < 100)    //If the player is shooting below them propel yourself up.
            {
                rigidbody.AddForce(new Vector3(0, laserJumpForce, 0));
            }
        }
    }
}