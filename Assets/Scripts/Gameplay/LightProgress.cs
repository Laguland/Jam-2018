using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProgress : MonoBehaviour {

	[SerializeField] private GameObject lampToShow;
	[SerializeField] private int numOfLamps;
	[SerializeField] private int enemiesToKill;

	private void Start() {
		lampToShow.SetActive(false);
	}

	public void DecreaseLampCounter() {
		numOfLamps--;
		if (numOfLamps == 0 && enemiesToKill == 0)
			lampToShow.SetActive(true);
	}
	
	public void DecreaseEnemyCounter() {
		enemiesToKill--;
		if (numOfLamps == 0 && enemiesToKill == 0)
			lampToShow.SetActive(true);
	}


}
