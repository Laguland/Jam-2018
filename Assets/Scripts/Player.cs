using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Player : Character {

    public Light playerLight;
    public bool isHoldingALightSource = false;

	private bool first75;
	private bool first50;
	private bool first25;

	void OnCollisionEnter(Collision other) {
		if (other.transform.tag == "Enemy") {
			transform.GetComponent<Rigidbody>().AddForce(other.transform.forward * 12.5f, ForceMode.Impulse);
			
			currentHealth -= 10f;

			if (currentHealth <= 0) {
				print("Player is dead.");
			} 
			else {
				Color32 c = playerLight.color;
				if (currentHealth <= 75) {
					if (!first75)
						playerLight.range -= 2.5f;
					playerLight.color = new Color32(224, 224, 115, 255);
					first75 = true;
				}
				if (currentHealth <= 50) {
					if (!first50)
						playerLight.range -= 2.5f;
					playerLight.color = new Color32(224, 184, 115, 255);
					first50 = true;
				}
				if (currentHealth <= 25) {
					if (!first25)
						playerLight.range -= 2.5f;
					playerLight.color = new Color32(224, 118, 115, 255);
					first25 = true;
				}
//				playerLight.color = new Color32();
			}
		}
	}
}
