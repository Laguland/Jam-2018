using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	public bool isRotating;
	private bool rotateRight;
	private Vector3 newRotatePos;
	private float rotateSpeed = 1;
	private float rotationTime;
    public int currentRot;
	
	private void Start() {
		offset = transform.position - player.transform.position;
	}

	private void Update() {
        if (Input.GetKey(KeyCode.E) && !isRotating)
        {
            StartCoroutine(RotateMe(Vector3.up * -90f, .5f));
            currentRot++;
            if (currentRot > 3)
            {
                currentRot = 0;
            }
        }

        if (Input.GetKey(KeyCode.Q) && !isRotating)
        {
            StartCoroutine(RotateMe(Vector3.up * 90f, .5f));
            currentRot--;
            if (currentRot < 0)
            {
                currentRot = 3;
            }
        }
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
