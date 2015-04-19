using UnityEngine;
using System.Collections;

public class ExplosionDammage : MonoBehaviour {
	
	private float inverseIgnit;

	private bool isExploding = false;

	public GameObject explosion;

	public float delay;

	public float radius;
	public float damage;

	void Update() {

		if (isExploding) {

			delay -= Time.deltaTime;

			if (delay <= 0) {

				Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

				foreach(Collider c in colliders) {

					if (c.gameObject.GetComponentInParent<CharacterController>() != null) {

						c.gameObject.GetComponentInParent<Enemy>().doDamage(damage);

					} else {

						continue;
					}
				}

				Instantiate(explosion, transform.position, Quaternion.identity);

				Destroy(this.gameObject);
			}
		}
	}

	void OnCollisionEnter(Collision other) {

		isExploding = true;
	}
}