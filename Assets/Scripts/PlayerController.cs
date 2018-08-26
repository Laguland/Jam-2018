
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 4f;

	private Vector3 forward, right;

	private void Start() {
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}

	private void Update() {

		LootAtMouse();
		if (Input.anyKey)
			Move();
	}

	private void LootAtMouse() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1000)) {
			transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
//			transform.localEulerAngles = new Vector3(-90, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
	}

	public void CameraRotated() {
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}

	private void Move() {
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
		
//		Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
//
//		if (heading != Vector3.zero)
//			transform.forward = heading;	
		
		transform.position += rightMovement;
		transform.position += upMovement;
	}
}
