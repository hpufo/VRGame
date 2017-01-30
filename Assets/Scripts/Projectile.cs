using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    private Transform thisTransform;        //Cached transform for this projectile

	// Use this for initialization
	void Start () {
        thisTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        thisTransform.position += Time.deltaTime * speed * thisTransform.forward;
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
