
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour {

	public float walkingSpeed = 6f;
	public float runningSpeed = 9.5f;
	private float moveSpeed;
	public bool canMove = true;
	public bool movementAllowed = true;
	
	private Vector3 forward, right;
	public Animator anim;

	public bool shooting;
	private bool running;

	private void Awake() {
		anim = GetComponent<Animator>();
	}

	private void Start() {
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
		moveSpeed = walkingSpeed;
	}

	private void Update() {

		if (!movementAllowed)
			return;
		
		LootAtMouse();

		if (shooting)
			anim.SetBool("shooting", false);
		
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			anim.SetBool("shooting", true);
		}

		// if shift is on hold, the player runs
		if (Input.GetKey(KeyCode.LeftShift)) {
			running = true;
			moveSpeed = runningSpeed;
		}

		// if shift is not on hold anymore, player should stop running
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			running = false;
			moveSpeed = walkingSpeed;
		}
		
		// checking if the player should move
		if (Input.anyKey && canMove)
			Move();
		else { // if the player is not walking, stop walking animation
			anim.SetBool("walking", false);
			anim.speed = 1f;
		}
	}

	private void LootAtMouse() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1000)) {
			transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
		}
	}

	// camera rotation when the player clicks on E or Q
	// the camera rotates 90 degrees
	public void CameraRotated() {
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}

	// player's movement
	private void Move() {
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");

		// checks if the player is moving at any direction
		if (rightMovement != Vector3.zero || upMovement != Vector3.zero) {
			anim.SetBool("walking", true);
			if (running)
				anim.speed = 4f;
			else
				anim.speed = 2f;
		} else { // in case that the player isn't moving anymore
			anim.SetBool("walking", false);
		}
		
		transform.position += rightMovement;
		transform.position += upMovement;
	}
}
