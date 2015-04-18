using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private float health;

	void Update() {
	
		transform.localScale = new Vector3(health * 0.001F, transform.localScale.y, transform.localScale.z);
	}

	public void setHealth(float health) {

		this.health = health;
	}
}