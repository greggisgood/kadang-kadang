using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour {
    public GameObject[] obstacles;
	int obstacleNo;
	public float maxPos = 2.2f;
	float delayTimer = 3f;
	float timer;


	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			Vector3 obstaclePos = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
			obstacleNo = Random.Range(0, 5);
			Instantiate(obstacles[obstacleNo], obstaclePos, transform.rotation);
			if (delayTimer > 0.6f) 
			{
				delayTimer -= 0.15f;
			}
			timer = delayTimer;
		}
	}
}
