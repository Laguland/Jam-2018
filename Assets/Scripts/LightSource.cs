using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        // player pick up a light source, self destroy
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Light source trigerred");
            Player player = other.gameObject.GetComponent<Player>();
            
            if(!player.isHoldingALightSource) // if not holding any light source 
            {
                player.isHoldingALightSource = true;
                player.lightColor = ColorUtility.ToHtmlStringRGBA(GetComponent<MeshRenderer>().material.color);                
                Debug.Log(player.isHoldingALightSource);
                Destroy(this.gameObject);
            }
        }
    }
}
