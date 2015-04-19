using UnityEngine;
using System.Collections;

public class Space : MonoBehaviour {

	void Update () {
	
		if (Input.GetKey(KeyCode.Space)) {

			Application.LoadLevel(1);
		}
	}
}