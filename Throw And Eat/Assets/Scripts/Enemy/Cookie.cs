using UnityEngine;
using System.Collections;

public class Cookie : MonoBehaviour {

	void OnControllerColliderHit(ControllerColliderHit other) {

		Debug.Log ("siojfopsoadkf");
		
		if (other.gameObject.tag == "Player") {
			
			other.gameObject.BroadcastMessage("doDammage", -10, SendMessageOptions.DontRequireReceiver);

			Destroy(this.gameObject);
		}
	}
}
