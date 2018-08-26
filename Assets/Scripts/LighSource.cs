using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighSource : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        // player pick up a light source, self destroy
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Light source trigerred");
            Player player = other.gameObject.GetComponent<Player>();
            
            player.isHoldingALightSource = true;
            Debug.Log(player.isHoldingALightSource);
            Destroy(this.gameObject);
        }
    }
}
