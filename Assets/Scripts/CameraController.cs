using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	private bool isRotating;
	private bool rotateRight;
	private Vector3 newRotatePos;
	private float rotateSpeed = 1;
	private float rotationTime;
	
	private void Start() {
		offset = transform.position - player.transform.position;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.E) && !isRotating)
			StartCoroutine(RotateMe(Vector3.up * -90f, .5f));

		if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
			StartCoroutine(RotateMe(Vector3.up * 90f, .5f));
	}

	private IEnumerator RotateMe(Vector3 byAngles, float inTime) {
		isRotating = true;
		var fromAngle = transform.rotation;
		var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
		for (var t = 0f; t < 1; t += Time.deltaTime/inTime) {
			transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
			yield return null;
			transform.rotation = toAngle;
		}
		isRotating = false;
		player.GetComponent<PlayerController>().CameraRotated();
	}

	private void LateUpdate() {
		transform.position = player.transform.position + offset;
	}
}
