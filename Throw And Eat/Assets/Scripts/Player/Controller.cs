using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	private Ammo ammoObject;
	private float forwardSpeed;
	private float sidewaysSpeed;
	private float sidewaysRot;
	private float verticalRot;
	private float verticalVel = 0;
	private Vector3 speed;
	private CharacterController characterController;
	public bool canMove = true;
	public float moveSpeed = 8.0F;
	public float mouseSensitivity = 2.0F;
	public float verticalRotRange = 60.0F;
	public float jumpHeight = 5.0F;

	void Awake () 
	{
		characterController = GetComponent<CharacterController> ();
	}

	void Update () 
	{

		sidewaysRot = Input.GetAxis("Mouse X") * mouseSensitivity;
		verticalRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		transform.Rotate(0, sidewaysRot, 0);
		verticalRot = Mathf.Clamp(verticalRot, -verticalRotRange, verticalRotRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRot, 0, 0);
		if (canMove) 
		{
			forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
			sidewaysSpeed = Input.GetAxis("Horizontal") * moveSpeed;
		} else {
			forwardSpeed = 0;
			sidewaysSpeed = 0;
		}
				
		if (Input.GetButton("Jump") && characterController.isGrounded) 
		{
			verticalVel = jumpHeight;
		}
					
		verticalVel += Physics.gravity.y * Time.deltaTime;
		speed = new Vector3(sidewaysSpeed, verticalVel, forwardSpeed);
		speed = transform.rotation * speed;
		characterController.Move(speed * Time.deltaTime);
	}
}
