using UnityEngine;
using System.Collections;

public class ThrownProjectile : MonoBehaviour
{

	[Tooltip("The amount of damage that the projectile does")]
	public int
		damage;

	[Tooltip("The time before the projectile is removed from the scene")]
	public float
		decayTime;

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, decayTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	/*void onCollisionEnter (Collision other)
	{
		if (other.gameObject.GetComponent<Enemy> ()) {
			other.gameObject.GetComponent<Enemy> ().DoDamage (damage);
		}
	}*/
}
