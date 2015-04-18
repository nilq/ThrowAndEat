using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100;

	public GameObject healthBar;

	void Update() {

		healthBar.transform.localScale = new Vector3(health / 100, transform.localScale.y, transform.localScale.z);
	}

	public void doDammage(float dammage) {

		health -= dammage;

		if (health <= 0) {

			Application.LoadLevel(Application.loadedLevel);
		}
	}
}