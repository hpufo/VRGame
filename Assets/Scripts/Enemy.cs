using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 5.0f;
    public GameObject expolsionPrefab;
    private GameObject target;
    private Rigidbody body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        SeekPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile"){
            Destroy(this.gameObject);
        }
        if (collision.gameObject.Equals(target))
        {
            Instantiate(expolsionPrefab, new Vector3(body.position.x,body.position.y,body.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void SeekPlayer()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
