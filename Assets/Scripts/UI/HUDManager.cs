using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    // get labels
    public Text label_EnCount;
    public Text label_LampCount;

    void Update()
    {
        GameObject[] aMonster = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] aLamp = GameObject.FindGameObjectsWithTag("Lamp");

        label_EnCount.text = aMonster.Length.ToString();
        label_LampCount.text = aLamp.Length.ToString();
    }
}
