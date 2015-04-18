/*
 * This script should be on the camera rendering the HUD.
 * Or whatever you want the weapon to be childed to, actually.
 */

using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour
{
	[Tooltip("Reference pointing to the main camera")]
	public GameObject 
		mainCameraObject;
	[Tooltip("The currently selected weapon")]
	public GameObject
		currentWeapon;
	[Tooltip("The prefab for Weapon one")]
	public GameObject
		weapon1;
	[Tooltip("The prefab for Weapon two")]
	public GameObject
		weapon2;
	[Tooltip("The prefab for Weapon three")]
	public GameObject
		weapon3;
	[Tooltip("The prefab for Weapon four")]
	public GameObject
		weapon4;

	// Use this for initialization
	void Start ()
	{
		if (!currentWeapon) {
			Debug.LogWarning ("You need to specify the currently selected weapon for things to go smoothly");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Weapon1")) {
			Destroy (currentWeapon);
			currentWeapon = Instantiate (weapon1);
			currentWeapon.transform.parent = transform;
			currentWeapon.GetComponent<Throw> ().cameraObject = mainCameraObject;
			currentWeapon.transform.localPosition = new Vector3 (0.331f, -0.204f, 0.411f);

		}
		if (Input.GetButtonDown ("Weapon2")) {
			Destroy (currentWeapon);
			currentWeapon = Instantiate (weapon2);
			currentWeapon.transform.parent = transform;
			currentWeapon.GetComponent<Throw> ().cameraObject = mainCameraObject;
			currentWeapon.transform.localPosition = new Vector3 (0.331f, -0.204f, 0.411f);
			
		}
		if (Input.GetButtonDown ("Weapon3")) {
			Destroy (currentWeapon);
			currentWeapon = Instantiate (weapon3);
			currentWeapon.transform.parent = transform;
			currentWeapon.GetComponent<Throw> ().cameraObject = mainCameraObject;
			currentWeapon.transform.localPosition = new Vector3 (0.331f, -0.204f, 0.411f);
			
		}
		if (Input.GetButtonDown ("Weapon4")) {
			Destroy (currentWeapon);
			currentWeapon = Instantiate (weapon4);
			currentWeapon.transform.parent = transform;
			currentWeapon.GetComponent<Throw> ().cameraObject = mainCameraObject;
			currentWeapon.transform.localPosition = new Vector3 (0.331f, -0.204f, 0.411f);
			
		}
	}
}
