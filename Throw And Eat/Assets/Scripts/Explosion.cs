using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public GameObject explosion;

	[Tooltip("Delay before the thing explodes.")]
	public float explotionDelay = 0.5f;

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag != "Player") {

			StartCoroutine("die");
		}
	}

	IEnumerator die () {

		yield return new WaitForSeconds(explotionDelay);

		Instantiate(explosion, transform.position, Quaternion.identity);
		
		Destroy(this.gameObject);
	}
}