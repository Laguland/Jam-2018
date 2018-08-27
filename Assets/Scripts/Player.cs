using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Player : Character {

    public Light playerLight;
    public bool isHoldingALightSource = false;

    // Use this for initialization
    void Start()
    {
        currentHealth = baseHealth;
    }

    void Update()
    {
        UpdateColor();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            transform.GetComponent<Rigidbody>().AddForce(other.transform.forward * 12.5f, ForceMode.Impulse);

            currentHealth -= 10f;
        }
    }

    void UpdateColor()
    {
        if (currentHealth <= 0)
        {
            print("Player is dead.");
            Death();
        }
        else
        {
            Color32 c = playerLight.color;
            if (currentHealth <= 75)
            {
                playerLight.range = 7.5f;
                playerLight.color = new Color32(224, 224, 115, 255);
            }
            if (currentHealth <= 50)
            {
                playerLight.range = 5f;
                playerLight.color = new Color32(224, 184, 115, 255);
            }
            if (currentHealth <= 25)
            {
                playerLight.range = 2.5f;
                playerLight.color = new Color32(224, 118, 115, 255);
            }
            //				playerLight.color = new Color32();
        }
    }

    override public void Death()
    {

    }
}


