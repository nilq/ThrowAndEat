using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public GameObject target;

	void Awake() {

		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {

		transform.LookAt(target.transform);
	}
}
