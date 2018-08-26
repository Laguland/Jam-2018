using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    // Collision
    // Once lamp is glowing destroy all enemies withing collider range
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            Destroy(other.gameObject);
    }
}
