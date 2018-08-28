using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCube : MonoBehaviour {

	[SerializeField] private Vector3 jumpDirection;
	[SerializeField] private float jumpForce;
	[SerializeField] private float jumpTime = 3f;

	private GameObject player;
	
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			player = other.gameObject;
			player.GetComponent<PlayerController>().canMove = false;
			player.GetComponent<Rigidbody>().AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
			StartCoroutine("Jumping");
		}
	}

	private IEnumerator Jumping() {
		yield return new WaitForSeconds(jumpTime);
		player.GetComponent<PlayerController>().canMove = true;
		player = null;
	}
	
}
