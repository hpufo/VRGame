using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private ParticleSystem ps;

	// Use this for initialization
	void Awake () {
        ps = GetComponent<ParticleSystem>();
        ps.Play();
        Destroy(this.gameObject, 5);
        Destroy(ps, 5);
	}
}
