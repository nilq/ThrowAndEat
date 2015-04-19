using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour {

	public GameObject target;

	public float maxSize, minSize;

	void Awake() {

		float size = Random.Range(minSize, maxSize);

		transform.localScale = new Vector3(size, size, size);
	}

	void Update () {

		transform.LookAt(target.transform.position);
	}
}