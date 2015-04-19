using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private bool shallHaveRigidbody = true;

	private bool hasRigidbody = false;

	private float verticalVel = 0;

	private Quaternion rotation;

	private Vector3 speed;

	private float distance;

	private CharacterController characterController;

	public bool isDead = false;

	public float dammage;

	public float antiSwarmDammage;

	public float health = 5.0F;

	public GameObject graphicsCookie;

	public float moveSpeed;
	public float jumpHeight;

	public float maxDistance;
	public float minDistance;

	public GameObject healthBar;

	public GameObject target;

	public GameObject dieParticle;

	void OnControllerColliderHit (ControllerColliderHit other) {

		if (other.gameObject.tag == "Player") {
			
			other.gameObject.BroadcastMessage ("doDammage", (dammage * 4) * Time.deltaTime, SendMessageOptions.DontRequireReceiver);

			doDamage((antiSwarmDammage * 30) * Time.deltaTime);
		}
	}

	void OnCollisionEnter (Collision other) {

		if (other.gameObject.tag == "DefaultWeapon") {
			
			doDamage (other.gameObject.GetComponent<ThrownProjectile> ().dammage);

			other.gameObject.tag = "Untagged";
		}

		if (other.gameObject.tag != "Enemy") {

			if (other.gameObject.tag != "Cookie") {

				if (shallHaveRigidbody) {

					if (hasRigidbody) {
						
						Destroy(this.GetComponent<Rigidbody>());
						
						hasRigidbody = false;
					}
				}
			}
		}
	}

	void Awake () {

		target = GameObject.FindGameObjectWithTag("Player");
	
		characterController = GetComponent<CharacterController> ();

		if (!hasRigidbody) {

			if (shallHaveRigidbody) {

				this.gameObject.AddComponent<Rigidbody> ();

				hasRigidbody = true;
			}
		}
	}

	void Update () {

		healthBar.gameObject.BroadcastMessage ("setHealth", health, SendMessageOptions.DontRequireReceiver);

		move ();
	}

	public void doDamage (float dammage) {

		health -= dammage;

		if (health <= 0) {

			die ();
		}
	}

	void move () {

		distance = Vector3.Distance (target.transform.position, this.transform.position);

		if (!isDead) {

			graphicsCookie.gameObject.tag = "Untagged";

			if (hasRigidbody) {

				if (!shallHaveRigidbody) {

					Destroy(GetComponent<Rigidbody> ());
					
					hasRigidbody = false;
				}
			}

			characterController.enabled = true;

			healthBar.SetActive (true);

			if (distance < maxDistance) {
				
				if (characterController.isGrounded) {
					
					verticalVel = jumpHeight;
				}
				
				rotation = Quaternion.LookRotation (target.transform.position - transform.position);
				
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, moveSpeed * Time.deltaTime);
				
				verticalVel += Physics.gravity.y * Time.deltaTime;		
				
				if (distance > minDistance) {
					
					speed = new Vector3 (0, verticalVel, moveSpeed);
					
				} else {
					
					speed = new Vector3 (0, verticalVel, 0);
				}
				
				speed = transform.rotation * speed;
				
				characterController.Move (speed * Time.deltaTime);
			
			}
		} else {

			healthBar.SetActive (false);

			verticalVel += Physics.gravity.y * Time.deltaTime;

			speed = new Vector3 (0, verticalVel, 0);
		}
	}

	void die () {

		isDead = true;

		shallHaveRigidbody = true;

		this.gameObject.AddComponent<Rigidbody> ();

		Destroy (this.GetComponent<CapsuleCollider> ());
		
		hasRigidbody = true;

		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (-90, transform.rotation.y, 0), moveSpeed * Time.deltaTime);

		characterController.enabled = false;

		graphicsCookie.gameObject.tag = "Cookie";

		Instantiate (dieParticle, transform.position, Quaternion.identity);
	}
}