using UnityEngine;
using System.Collections;

public class SplashCam : MonoBehaviour {
	
	private float angleV;

	public Transform target;

	public float speed;

	public float radius = 5;

	public bool shallLookAt = true;

	void Update() {

		angleV += speed * Time.deltaTime;

		transform.position = new Vector3(Mathf.Cos(angleV)*radius + target.position.x, target.position.y, Mathf.Sin(angleV)*radius + target.position.z);

		if (shallLookAt) {

			transform.LookAt(target.position);
		}
	}
}