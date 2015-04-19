using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Throw : MonoBehaviour {

	/*
	 *
	 *	0 = Flintlock;
	 *	1 = Valter;
	 *	2 = RocketLauncher;
	 *
	*/

	private RectTransform ammoGUI0;
	private RectTransform ammoGUI1;
	private RectTransform ammoGUI2;

	private Text ammoText0;
	private Text ammoText1;
	private Text ammoText2;

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

	SoundRandomizer soundthing;	//It's getting late, okay?

	void Awake() {

		ammoObject = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Ammo>();

		ammoGUI0 = GameObject.FindGameObjectWithTag("AmmoGUI0").GetComponent<RectTransform>();
		ammoGUI1 = GameObject.FindGameObjectWithTag("AmmoGUI1").GetComponent<RectTransform>();
		ammoGUI2 = GameObject.FindGameObjectWithTag("AmmoGUI2").GetComponent<RectTransform>();
		
		ammoText0 = GameObject.FindGameObjectWithTag("AmmoText0").GetComponent<Text>();
		ammoText1 = GameObject.FindGameObjectWithTag("AmmoText1").GetComponent<Text>();
		ammoText2 = GameObject.FindGameObjectWithTag("AmmoText2").GetComponent<Text>();
		
		if (projectile.gameObject.name == "Flintlock") {
			
			ammoGUI0.anchoredPosition = new Vector2(-100, 50);
			ammoGUI1.anchoredPosition = new Vector2(-100, 999999);
			ammoGUI2.anchoredPosition = new Vector2(-100, 999999);
			
		} else if (projectile.gameObject.name == "Valter") {
			
			ammoGUI1.anchoredPosition = new Vector2(-100, 50);
			ammoGUI0.anchoredPosition = new Vector2(-100, 999999);
			ammoGUI2.anchoredPosition = new Vector2(-100, 999999);
			
		} else if (projectile.gameObject.name == "RocketLauncher") {
			
			ammoGUI2.anchoredPosition = new Vector2(-250, 50);
			ammoGUI0.anchoredPosition = new Vector2(-100, 999999);
			ammoGUI1.anchoredPosition = new Vector2(-100, 999999);
		}
		
		startDelay = delay;
		
		ammo = new int[4];
		
		ammoText0.text = "Flintlocks: " + ammoObject.ammo[0].ToString();
		ammoText1.text = "Valters: " + ammoObject.ammo[1].ToString();
		ammoText2.text = "Rocket Launchers: " + ammoObject.ammo[2].ToString();
	}



	void Start () {

		try {

			soundthing = gameObject.GetComponent<SoundRandomizer>();
			soundthing.ToString();

		} catch {

			Debug.LogWarning("This thing does not have a SoundRandomizer, so there won't be any sound.");
		}

	}
	
	// Update is called once per frame
	void Update () {

		delay -= Time.deltaTime;

		ammoText0.text = "Flintlocks: " + ammoObject.ammo[0].ToString();
		ammoText1.text = "Valters: " + ammoObject.ammo[1].ToString();
		ammoText2.text = "Rocket Launchers: " + ammoObject.ammo[2].ToString();

		if (Input.GetButton ("Fire1")) {

			ammo[0] = ammoObject.ammo[0];
			ammo[1] = ammoObject.ammo[1];
			ammo[2] = ammoObject.ammo[2];

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
						
						ammoText0.text = "Flintlocks: " + ammoObject.ammo[0].ToString();
						ammoText1.text = "Valters: " + ammoObject.ammo[1].ToString();
						ammoText2.text = "Rocket Launchers: " + ammoObject.ammo[2].ToString();
						
						soundthing.playRandomClip();

					}
				} else if (projectile.gameObject.name == "Valter") {
					
					if (ammo[1] > 0) {
						
						thrown = Instantiate (projectile);

						thrown.transform.position = Camera.main.transform.position;

						thrown.GetComponent<Rigidbody> ().velocity = (Camera.main.transform.forward * throwForce) + new Vector3 (0, throwAngle, 0);
						thrown.GetComponent<Rigidbody> ().maxAngularVelocity = Mathf.Pow (10, 1000);
						thrown.GetComponent<Rigidbody> ().angularVelocity = angularVelocity;
						
						ammoObject.ammo[1] -= 1;

						ammoText0.text = "Flintlocks: " + ammoObject.ammo[0].ToString();
						ammoText1.text = "Valters: " + ammoObject.ammo[1].ToString();
						ammoText2.text = "Rocket Launchers: " + ammoObject.ammo[2].ToString();
						
						soundthing.playRandomClip();
					}
				} else if (projectile.gameObject.name == "RocketLauncher") {
				
					if (ammo[2] > 0) {
						
						thrown = Instantiate (projectile);

						thrown.transform.position = Camera.main.transform.position;

						thrown.GetComponent<Rigidbody> ().velocity = (Camera.main.transform.forward * throwForce) + new Vector3 (0, throwAngle, 0);
						thrown.GetComponent<Rigidbody> ().maxAngularVelocity = Mathf.Pow (10, 1000);
						thrown.GetComponent<Rigidbody> ().angularVelocity = angularVelocity;
						
						ammoObject.ammo[2] -= 1;

						ammoText0.text = "Flintlocks: " + ammoObject.ammo[0].ToString();
						ammoText1.text = "Valters: " + ammoObject.ammo[1].ToString();
						ammoText2.text = "Rocket Launchers: " + ammoObject.ammo[2].ToString();
						
						soundthing.playRandomClip();
					}
				}

				delay = startDelay;
			}

			ammoText0.text = "Flintlocks: " + ammoObject.ammo[0].ToString();
			ammoText1.text = "Valters: " + ammoObject.ammo[1].ToString();
			ammoText2.text = "Rocket Launchers: " + ammoObject.ammo[2].ToString();
		}
	}
}
