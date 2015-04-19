using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private float startDelay;

	public GameObject thingToSpawn;
		
	public float delay;

	void Start() {

		startDelay = delay;
	}

	void Update() {

		delay -= Time.deltaTime;

		if (delay <= 0) {

			Instantiate(thingToSpawn, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));

			delay = startDelay;
		}
	}
}