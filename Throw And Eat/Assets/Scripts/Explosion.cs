using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public GameObject explosion;

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag != "Player") {

			StartCoroutine("die");
		}
	}

	IEnumerator die () {

		yield return new WaitForSeconds(0.05F);

		Instantiate(explosion, transform.position, Quaternion.identity);
		
		Destroy(this.gameObject);
	}
}