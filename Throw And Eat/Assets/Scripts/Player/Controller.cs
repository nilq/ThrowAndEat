using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	private float forwardSpeed;
	private float sidewaysSpeed;

	private float sidewaysRot;
	private float verticalRot;

	private float verticalVel = 0;

	private Vector3 speed;

	private CharacterController characterController;

	public float movSpeed = 8.0F;
	public float mouseSensitivity = 2.0F;
	public float verticalRotRange = 60.0F;
	public float jumpHeight = 5.0F;

	void Awake() {

		characterController = GetComponent<CharacterController>();
	}

	void Update() {
	
		sidewaysRot = Input.GetAxis("Mouse X") * mouseSensitivity;
		verticalRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
				
		transform.Rotate(0, sidewaysRot, 0);
				
		verticalRot = Mathf.Clamp(verticalRot, -verticalRotRange, verticalRotRange);
				
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRot, 0, 0);
				
				
		forwardSpeed = Input.GetAxis("Vertical") * movSpeed;
		sidewaysSpeed = Input.GetAxis("Horizontal") * movSpeed;
				
		if (Input.GetButton("Jump") && characterController.isGrounded) {

			verticalVel = jumpHeight;
		}
					
		verticalVel += Physics.gravity.y * Time.deltaTime;		
						
		speed = new Vector3(sidewaysSpeed, verticalVel, forwardSpeed);
						
		speed = transform.rotation * speed;
						
		characterController.Move(speed * Time.deltaTime);
	}
}
