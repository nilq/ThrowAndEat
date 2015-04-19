/*
 * Destroy whatever object it is attatched to.
*/
using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	[Tooltip("How long to wait before destroying the gameObject")]
	public float timer;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, timer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
