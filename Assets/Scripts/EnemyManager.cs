using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyBomber;
    public float spawnTimer = 3f;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        //Call Spawn function after the set time, then continue to call at the spawn time.
        InvokeRepeating("Spawn", 1, spawnTimer);
	}

    void Spawn()
    {
        //Grabbing a random index from the array
        int randIndex = Random.Range(0, spawnPoints.Length);
        //Create a new enemyBomber
        Instantiate(enemyBomber, spawnPoints[randIndex].position, spawnPoints[randIndex].rotation);
    }
}
