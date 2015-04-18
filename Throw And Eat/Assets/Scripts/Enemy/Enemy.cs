﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float verticalVel = 0;

	private Quaternion rotation;

	private Vector3 speed;

	private float distance;

	private CharacterController characterController;

	public float moveSpeed;
	public float jumpHeight;

	public float maxDistance;
	public float minDistance;

	public GameObject target;

	void Awake() {
	
		characterController = GetComponent<CharacterController>();
	}

	void Update() {

		move();
	}

	public void move() {

		distance = Vector3.Distance(target.transform.position, this.transform.position);
		
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
	}
}