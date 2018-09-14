using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public GameObject target;

	void Awake() {
		if(target == null)
			target = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update() {

		transform.LookAt(target.transform);
	}
}
