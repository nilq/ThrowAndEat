using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {

	private Ammo ammoObject;

	void Awake() {

		ammoObject = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Ammo>();
	}

	void OnControllerColliderHit (ControllerColliderHit other)
	{
		Debug.Log("OSTDYUASHBDHUBSDFNSOFNSJFNSOnsdaoaifnfsnafoidsfjnvdasofondisfndisofndsif");
	}

	/*void OnControllerColliderHit(ControllerColliderHit other) {

		Debug.Log ("There was a collision: "+ other.transform);

		if (other.gameObject.tag == "Player") {

			if (this.gameObject.tag == "Ammo0") {

				ammoObject.ammo[0] += 10;
				
				Destroy(this.gameObject);
			}
			
		} else if (other.gameObject.tag == "Player") {

			if (this.gameObject.tag == "Ammo1") {
			
				ammoObject.ammo[1] += 10;
				
				Destroy(this.gameObject);
			}
			
		} else if (other.gameObject.tag == "Player") {

			if (this.gameObject.tag == "Ammo2") {

				ammoObject.ammo[2] += 10;
				
				Destroy(this.gameObject);
			}
			
		} else if (other.gameObject.tag == "Player") {

			if (this.gameObject.tag == "Ammo3") {

				ammoObject.ammo[3] += 10;
				
				Destroy(this.gameObject);
			}
			
		} else if (other.gameObject.tag == "Player") {

			if (this.gameObject.tag == "Ammo4") {

				ammoObject.ammo[4] += 10;
				
				Destroy(this.gameObject);
			}
		}
	}	*/
}