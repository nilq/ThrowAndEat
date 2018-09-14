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

					Enemy enemyComponent = c.gameObject.GetComponentInParent<Enemy>();

					if (enemyComponent != null) {

						enemyComponent.doDamage(damage);

					} else {

						continue;
					}
				}

				Instantiate(explosion, transform.position, Quaternion.identity);

				Destroy(this.gameObject, delay);
			}
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag != "Player")
			isExploding = true;
	}
}