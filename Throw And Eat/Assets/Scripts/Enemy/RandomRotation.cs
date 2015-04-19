using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	void Awake() {

		transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
	}
}
