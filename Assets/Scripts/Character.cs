using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	public float baseHealth = 100f;
	public float currentHealth;
	protected float moveSpeed;

    public abstract void Death();
}
