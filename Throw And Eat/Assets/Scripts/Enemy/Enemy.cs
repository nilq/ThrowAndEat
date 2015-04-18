using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float verticalVel = 0;

	private Quaternion rotation;

	private Vector3 speed;

	private float distance;

	private CharacterController characterController;

	public bool isDead = false;

	public float dammage;

	public float health = 5.0F;

	public float moveSpeed;
	public float jumpHeight;

	public float maxDistance;
	public float minDistance;

	public GameObject healthBar;

	public GameObject target;

	void OnControllerColliderHit(ControllerColliderHit other) {

		if (other.gameObject.tag == "Player") {
			
			other.gameObject.BroadcastMessage("doDammage", dammage, SendMessageOptions.DontRequireReceiver);
		}
	}

	void Awake() {
	
		characterController = GetComponent<CharacterController>();
	}

	void Update() {

		//doDamage(0.7F);

		healthBar.gameObject.BroadcastMessage("setHealth", health, SendMessageOptions.DontRequireReceiver);

		move();
	}

	public void doDamage(float dammage) {

		health -= dammage;

		if (health <= 0) {

			die();
		}
	}

	void move() {

		distance = Vector3.Distance(target.transform.position, this.transform.position);

		if (!isDead) {

			Destroy(GetComponent<Rigidbody>());

			characterController.enabled = true;

			healthBar.SetActive(true);

			if (distance < maxDistance) {
				
				if (characterController.isGrounded) {
					
					verticalVel = jumpHeight;
				}
				
				rotation = Quaternion.LookRotation(target.transform.position - transform.position);
				
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, moveSpeed * Time.deltaTime);
				
				verticalVel += Physics.gravity.y * Time.deltaTime;		
				
				if (distance > minDistance) {
					
					speed = new Vector3(0, verticalVel, moveSpeed);
					
				} else {
					
					speed = new Vector3(0, verticalVel, 0);
				}
				
				speed = transform.rotation * speed;
				
				characterController.Move(speed * Time.deltaTime);
			}
		} else {

			healthBar.SetActive(false);

			verticalVel += Physics.gravity.y * Time.deltaTime;

			speed = new Vector3(0, verticalVel, 0);
		}
	}

	void die() {

		isDead = true;

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, transform.rotation.y, 0), moveSpeed * Time.deltaTime);

		characterController.enabled = false;

		this.gameObject.AddComponent<Rigidbody>();
	}
}