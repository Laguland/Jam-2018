using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : Character {

    public Light playerLight;

	void OnCollisionEnter(Collision other) {
		if (other.transform.tag == "Enemy") {
			transform.GetComponent<Rigidbody>().AddForce(other.transform.forward * 12.5f, ForceMode.Impulse);
			
			base.currentHealth -= 10f;

			if (base.currentHealth <= 0) {
				print("Player is dead.");
			}
		}
	}
}
