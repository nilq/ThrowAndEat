using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{

	[Tooltip("The object to be thrown. Should have a ThrownProjectile script to work")]
	public GameObject
		projectile;

	[Tooltip("The camera or object pointing the right default direction")]
	public GameObject
		cameraObject;

	[Tooltip("The amount of force to apply to the weapon upon launch")]
	public float
		throwForce;

	[Tooltip("The angle at which the object is thrown")]
	public float
		throwAngle;

	//The default direction
	Vector3 dir;



	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			GameObject thrown = Instantiate (projectile);
			thrown.transform.position = cameraObject.transform.position;
			thrown.GetComponent<Rigidbody> ().velocity = (transform.forward * throwForce);
		}
	}
}
