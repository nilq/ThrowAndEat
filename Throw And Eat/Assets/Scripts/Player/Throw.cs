using UnityEngine;
using System.Collections;

public abstract class Throw : MonoBehaviour
{

	/*
	 *
	 *	0 = Flintlock;
	 *	1 = Valter;
	 *	2 = RocketLauncher;
	 *	3 = Canon;
	 *
	*/

	private int[] ammo;

	private float startDelay;

	private Ammo ammoObject;

	[Tooltip("The object to be thrown. Should have a ThrownProjectile script to work")]
	public GameObject
		projectile;

	[Tooltip("The amount of force to apply to the weapon upon launch")]
	public float
		throwForce;

	[Tooltip("The angle at which the object is thrown")]
	public float
		throwAngle;

	[Tooltip("Delay between throws in seconds")]
	public float 
		delay;

	[Tooltip("The angular velocity that the projectile is spawned with")]
	public Vector3
		angularVelocity;

	//The default direction
	Vector3 dir;

	// Use this for initialization
	void Start ()
	{
		ammoObject = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Ammo>();

		startDelay = delay;

		ammo = new int[5];
	}
	
	// Update is called once per frame
	void Update ()
	{
		delay -= Time.deltaTime;

		if (Input.GetButton ("Fire1")) {

			ammo[0] = ammoObject.ammo[0];
			ammo[1] = ammoObject.ammo[1];
			ammo[2] = ammoObject.ammo[2];
			ammo[3] = ammoObject.ammo[3];

			if (delay <= 0) {

				GameObject thrown;

				if (projectile.gameObject.name == "Flintlock") {

					if (ammo[0] > 0) {

						thrown = Instantiate (projectile);

						thrown.transform.position = Camera.main.transform.position;

						thrown.GetComponent<Rigidbody> ().velocity = (Camera.main.transform.forward * throwForce) + new Vector3 (0, throwAngle, 0);
						thrown.GetComponent<Rigidbody> ().maxAngularVelocity = Mathf.Pow (10, 1000);
						thrown.GetComponent<Rigidbody> ().angularVelocity = angularVelocity;

						ammoObject.ammo[0] -= 1;
					}
				} else if (projectile.gameObject.name == "Valter") {
					
					if (ammo[1] > 0) {
						
						thrown = Instantiate (projectile);

						thrown.transform.position = Camera.main.transform.position;

						thrown.GetComponent<Rigidbody> ().velocity = (Camera.main.transform.forward * throwForce) + new Vector3 (0, throwAngle, 0);
						thrown.GetComponent<Rigidbody> ().maxAngularVelocity = Mathf.Pow (10, 1000);
						thrown.GetComponent<Rigidbody> ().angularVelocity = angularVelocity;
						
						ammoObject.ammo[1] -= 1;
					}
				} else if (projectile.gameObject.name == "RocketLauncher") {
					
					if (ammo[2] > 0) {
						
						thrown = Instantiate (projectile);

						thrown.transform.position = Camera.main.transform.position;

						thrown.GetComponent<Rigidbody> ().velocity = (Camera.main.transform.forward * throwForce) + new Vector3 (0, throwAngle, 0);
						thrown.GetComponent<Rigidbody> ().maxAngularVelocity = Mathf.Pow (10, 1000);
						thrown.GetComponent<Rigidbody> ().angularVelocity = angularVelocity;
						
						ammoObject.ammo[2] -= 1;
					}
				} else if (projectile.gameObject.name == "RocketLauncher") {
					
					if (ammo[3] > 0) {
						
						thrown = Instantiate (projectile);
						
						thrown.transform.position = Camera.main.transform.position;

						thrown.GetComponent<Rigidbody> ().velocity = (Camera.main.transform.forward * throwForce) + new Vector3 (0, throwAngle, 0);
						thrown.GetComponent<Rigidbody> ().maxAngularVelocity = Mathf.Pow (10, 1000);
						thrown.GetComponent<Rigidbody> ().angularVelocity = angularVelocity;
						
						ammoObject.ammo[3] -= 1;
					}
				} else if (projectile.gameObject.name == "Canon") {
					
					if (ammo[4] > 0) {
						
						thrown = Instantiate (projectile);
						
						thrown.transform.position = Camera.main.transform.position;
						
						thrown.GetComponent<Rigidbody> ().velocity = (Camera.main.transform.forward * throwForce) + new Vector3 (0, throwAngle, 0);
						thrown.GetComponent<Rigidbody> ().maxAngularVelocity = Mathf.Pow (10, 1000);
						thrown.GetComponent<Rigidbody> ().angularVelocity = angularVelocity;
						
						ammoObject.ammo[4] -= 1;
					}
				}

				delay = startDelay;
			}
		}
	}
}
