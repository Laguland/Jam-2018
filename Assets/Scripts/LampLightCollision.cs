using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightCollision : MonoBehaviour {

    public float lifeRegenPerSecond = 30f;
    private bool startRegenLife = false;
    private float timer = 0f;
    Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // if player within start life regen
        if(startRegenLife)
        {
            // regen X amount of life every second starting from 0
            if(timer%1 == 0)
            {
                // it is safe to add max life per second
                if (player.currentHealth < player.baseHealth - lifeRegenPerSecond)
                {
                    player.currentHealth += lifeRegenPerSecond;
                }
                // add missing life but does not overextend it
                else
                {
                    player.currentHealth = player.baseHealth;
                }
            }

            // add frame time to timer
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
    }

    // Collision
    // Once lamp is glowing destroy all enemies withing collider range
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            Destroy(other.gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            startRegenLife = true;
            Debug.Log("start life regen");
            player = other.GetComponent<Player>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("stop life regen");
            startRegenLife = false;
        }
    }
}
