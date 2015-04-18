/*
 * Just place anywhere in the scene
*/
using UnityEngine;
using System.Collections;

public class CursorMannager : MonoBehaviour
{
	bool cursorLocked = false;
	
	
	// Use this for initialization
	void Start ()
	{
		unlockCursor ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!cursorLocked) {
			if (Input.GetButtonDown ("Fire1")) {
				lockCursor ();
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				unlockCursor ();
			}
		}
	}
	
	void unlockCursor ()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		cursorLocked = false;
	}
	
	void lockCursor ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cursorLocked = true;
	}
}
