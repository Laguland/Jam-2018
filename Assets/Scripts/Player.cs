using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Player : Character {

	public Light playerLight;
	public bool isHoldingALightSource;

	private void OnCollisionEnter(Collision other) {
		if (other.transform.tag == "Enemy") {
			currentHealth -= 10f;
		}
	}

	private void OnCollisionStay(Collision other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			if (other.gameObject.GetComponent<Animator>().GetBool("attack"))
				currentHealth -= 0.03f;
			print("Health : " + currentHealth);
		}
	}

	private void Start() {
		currentHealth = baseHealth;
	}

	private void Update() {
		UpdateColor();
	}

	private void UpdateColor() {
		if (currentHealth <= 0) {
			print("Player is dead.");
			Death();
		} else {
			if (currentHealth <= 100) {
				playerLight.range = 15f;
				playerLight.color = new Color32(137, 224, 115, 255);
			}

			if (currentHealth <= 75) {
				playerLight.range = 12.5f;
				playerLight.color = new Color32(224, 224, 115, 255);
			}

			if (currentHealth <= 50) {
				playerLight.range = 10f;
				playerLight.color = new Color32(224, 184, 115, 255);
			}

			if (currentHealth <= 25) {
				playerLight.range = 7.5f;
				playerLight.color = new Color32(224, 118, 115, 255);
			}
		}
	}

	public override void Death() { }
}


