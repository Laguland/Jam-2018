using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : Character {

	public Light playerLight;
	public bool isHoldingALightSource;
	public string lightColor;

	private void Start() {
		currentHealth = baseHealth;
	}

	private void Update() {
		UpdateColor();
	}

	private void UpdateColor()
    {
		if (currentHealth <= 0)
        {
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

	public override void GetDamage(float amount) {
		base.currentHealth -= amount;
		print("Health : " + currentHealth);
	}

	public override void Death() {
		GetComponent<Animator>().SetBool("dead", true);
		GetComponent<PlayerController>().movementAllowed = false;
	}
}


