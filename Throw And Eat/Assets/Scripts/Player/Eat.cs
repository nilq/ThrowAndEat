﻿/*
 * Script might be put anywhere, but do remember to add reference to main camera.
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Eat : MonoBehaviour {

	private int cookieCounter;

	private Ammo ammoComponent;

	private Text counterComponent;

	[Tooltip("The main camera in the scene, dumbass")]
	public GameObject
		mainCamera;

	[Tooltip("The player. Which should have the specialized character controller.")]
	public GameObject
		player;

	[Tooltip("Breadcrumb prefab as effect")]
	public GameObject
		breadcrumbs;

	[Tooltip("The amount the player heals by eating 1 gingerbread man")]
	public float
		healthHealed = 10;

	[Tooltip("The amount of time it takes for the player to consume his enemies")]
	public float
		eatTime = 3;

	[Tooltip("The maximum distance at which it is possible to eat a gingerbreadman")]
	public float
		maxDist = 4;

	bool chomping = false;  //Wheter or not the player is eating a cookie.

	SoundRandomizer soundthing;

	int layerMask;

	// Use this for initialization
	void Start () {

		counterComponent = GameObject.FindGameObjectWithTag("CookieCounter").GetComponent<Text>();

		ammoComponent = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Ammo>();
		layerMask = ~(1 << 9);	//All layers except nr. 9, the player; hopefully

		try{
			soundthing = gameObject.GetComponent<SoundRandomizer>();
		}catch{
			Debug.LogWarning("This thing does not have a SoundRandomizer, so there won't be any sound.");
		}

		counterComponent.text = "People Eaten: " + cookieCounter;

		StartCoroutine("regenerateFlintlocks");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire2")) {
			RaycastHit hit;

			Ray screenMiddle = new Ray (mainCamera.transform.position, mainCamera.transform.forward);
			if (Physics.Raycast (screenMiddle, out hit, maxDist, layerMask)) {

				if (chomping == false && hit.collider.gameObject.tag == "Cookie") {
					chomping = true;
					StartCoroutine ("eatGingerbread");
					Destroy (hit.collider.gameObject);

					cookieCounter++;

					counterComponent.text = "People Eaten: " + cookieCounter;
				}
			}
		}
	}

	IEnumerator eatGingerbread () {

		player.GetComponent<Controller> ().canMove = false;

		if (Random.Range(0, 2) == 0) {
			
			ammoComponent.ammo[0] += 10;
			
		} else if (Random.Range(0, 2) == 1) {
			
			ammoComponent.ammo[1] += 10;
			
		}

		if (Random.Range(0, 3) == 0) {

			ammoComponent.ammo[2]++;
		}

		for (int i = (int)eatTime*10; i > 0; i -= 2) {  //Wait for eatTime and spawn breadcrubms meanwhile

			Instantiate (breadcrumbs, mainCamera.transform.position, mainCamera.transform.localRotation);
			yield return new WaitForSeconds (0.2f);
			soundthing.playRandomClip();
			if (player.GetComponent<PlayerHealth> ().health < 100) {
				player.GetComponent<PlayerHealth> ().health += (healthHealed * (0.2f / eatTime));
			}
		}
		player.GetComponent<Controller> ().canMove = true;
		chomping = false;
	}

	IEnumerator regenerateFlintlocks(){
		while (true){
			yield return new WaitForSeconds (4);
			ammoComponent.ammo[0] += 1;
		}
	}
}
