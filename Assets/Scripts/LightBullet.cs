using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBullet : MonoBehaviour {

    public float speed;
    public float damage;

    private float counter;
	
	// Update is called once per frame
	void Update () {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
	    counter += Time.deltaTime;
	    
	    if (counter >= 3f)
	        Destroy(gameObject);
	}

    // collision check
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT ENEMY");
            EnemyHit(col.gameObject);
            Destroy(gameObject);
        }
    }

    // enemy hit logic
    void EnemyHit(GameObject enemy)
    {
        Destroy(enemy);
    }
}
