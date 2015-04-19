using UnityEngine;
using System.Collections;

public class KnockBack : MonoBehaviour
{
	[Tooltip("Multiplier used when adding the inherent velocity.")]
	public float
		forceMultiplyer = 5;


	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Enemy") {
			if (other.rigidbody) {
				other.rigidbody.AddForce (this.gameObject.GetComponent<Rigidbody> ().velocity * forceMultiplyer);

			}
		}
	}
}
