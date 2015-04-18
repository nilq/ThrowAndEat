/*
 * Script might be put anywhere, but do remember to add reference to main camera.
*/
using UnityEngine;
using System.Collections;

public class Eat : MonoBehaviour
{

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

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire2")) {
			RaycastHit hit;

			Ray screenMiddle = new Ray (mainCamera.transform.position, mainCamera.transform.forward);
			if (Physics.Raycast (screenMiddle, out hit, maxDist)) {

				if (chomping == false && hit.collider.gameObject.tag == "Cookie") {
					chomping = true;
					StartCoroutine ("eatGingerbread");
					Destroy (hit.collider.gameObject);
				}
			}
		}
	}

	IEnumerator eatGingerbread ()
	{
		player.GetComponent<Controller> ().canMove = false;

		for (int i = (int)eatTime*10; i > 0; i -= 2) {  //Wait for eatTime and spawn breadcrubms meanwhile
			//TODO: Sound effect
			Instantiate (breadcrumbs, mainCamera.transform.position, mainCamera.transform.localRotation);
			yield return new WaitForSeconds (0.2f);

			if (player.GetComponent<PlayerHealth> ().health < 100) {
				player.GetComponent<PlayerHealth> ().health += (healthHealed * (0.2f / eatTime));
			}
		}
		player.GetComponent<Controller> ().canMove = true;
		chomping = false;
	}
}
