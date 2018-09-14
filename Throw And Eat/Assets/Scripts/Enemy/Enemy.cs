using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float verticalVel = 0;

	private Quaternion rotation;

	private Vector3 speed;

	private float distance;

	private CharacterController characterController;

	private Rigidbody rigidBody;

	public bool isDead = false;

	public float dammage;

	public float antiSwarmDammage;

	public float health = 5.0F;

	[Tooltip("The part of the enemy that stays behind as a delicious cookie when it dies.")]
	public GameObject graphicsCookie;

	public float moveSpeed;
	public float jumpHeight;

	[Tooltip("Maximum chase distance")]
	public float maxDistance;
	[Tooltip("Minimum chase distance. Respect personal space.")]
	public float minDistance;

	[Tooltip("If velocity is less than value, remove rigidbody.")]
	public float disableRigidbodyThreshold = 0.3f;

	public GameObject healthBar;

	public GameObject target;

	public GameObject dieParticle;

	void OnControllerColliderHit (ControllerColliderHit other) {

		if (other.gameObject.tag == "Player") {
			
			other.gameObject.BroadcastMessage ("doDammage", dammage * Time.deltaTime, SendMessageOptions.DontRequireReceiver);

			doDamage((antiSwarmDammage) * Time.deltaTime);
		} 
		else if (other.gameObject.tag == "DefaultWeapon") {
			
			doDamage (other.gameObject.GetComponent<ThrownProjectile> ().dammage);

			other.gameObject.tag = "Untagged";
		}
	}

	void OnCollisionEnter (Collision other) {
	}

	void Start () {

		target = GameObject.FindGameObjectWithTag("Player");
	
		characterController = GetComponent<CharacterController> ();
	}

	void Update () {

		healthBar.gameObject.BroadcastMessage ("setHealth", health, SendMessageOptions.DontRequireReceiver);

		if (!isDead) {
			move ();
		}
		else if(rigidBody!=null && rigidBody.velocity.normalized.magnitude < disableRigidbodyThreshold){
			Destroy(rigidBody);
		}
	}

	public void doDamage (float dammage) {

		if(isDead)
			return;

		//Health bar shows up first time it is damaged
		healthBar.SetActive (true);

		health -= dammage;

		if (health <= 0) {

			die ();
		}
	}

	void move () {

		distance = Vector3.Distance (target.transform.position, this.transform.position);

		characterController.enabled = true;

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
	}

	void die () {

		healthBar.SetActive(false);

		isDead = true;

		rigidBody = this.gameObject.AddComponent<Rigidbody> ();

		characterController.enabled = false;

		//Become edible
		graphicsCookie.gameObject.tag = "Cookie";

		Instantiate (dieParticle, transform.position, Quaternion.identity);
	}
}