/*
 * Ths script should be put on a UI object.
 * It will only display that object in a few seconds when Fire2 is pressed.
*/
using UnityEngine;
using System.Collections;

public class NomNomCrosshairs : MonoBehaviour
{
	[Tooltip("Amount of time it should stay visible")]
	public float
		visibleTime = 1;

	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (1000000000, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire2")) {
			//TODO: Add sound effect
			StartCoroutine ("display");
		}
	}

	IEnumerator display ()
	{
		gameObject.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (0, 0);
		yield return new WaitForSeconds (visibleTime);
		gameObject.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (1000000000, 0);
	}
}
