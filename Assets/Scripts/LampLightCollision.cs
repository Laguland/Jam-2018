using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightCollision : MonoBehaviour {

    public float lifeRegenPerSecond = 5f;
    private bool startRegenLife = false;
    Player player;

    private bool regen;
    
    // Update is called once per frame

    // Collision
    // Once lamp is glowing destroy all enemies withing collider range
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player")) {
            startRegenLife = true;
            Debug.Log("start life regen");
            player = other.GetComponent<Player>();
            StartCoroutine("GenerateHealth");
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (regen)
                StartCoroutine("GenerateHealth");
        }
    }

    private IEnumerator GenerateHealth() {
        if (startRegenLife) {
            regen = false;
            // it is safe to add max life per second
            if (player.currentHealth < player.baseHealth - lifeRegenPerSecond) {
                player.currentHealth += lifeRegenPerSecond;
            }
            // add missing life but does not overextend it
            else {
                player.currentHealth = player.baseHealth;
            }
            yield return new WaitForSeconds(2f);
        }
        regen = true;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("stop life regen");
            startRegenLife = false;
        }
    }
}
