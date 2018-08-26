using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBullet : MonoBehaviour {

    public float speed;
    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
	}

    // collision check
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT ENEMY");
            EnemyHit(col.gameObject);
            Destroy(this);
        }
    }

    // enemy hit logic
    void EnemyHit(GameObject enemy)
    {
        Destroy(enemy);
    }
}
