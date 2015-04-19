using UnityEngine;
using System.Collections;

public class ThrownProjectile : MonoBehaviour
{

	[Tooltip("The amount of damage that the projectile does")]
	public float 
		dammage = 15F;

	[Tooltip("The time before the projectile is removed from the scene")]
	public float
		decayTime = 5f;

	void Start ()
	{
		this.gameObject.tag = "DefaultWeapon";
		Destroy (gameObject, decayTime);
	}
}
