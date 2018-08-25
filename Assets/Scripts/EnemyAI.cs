using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    GameObject player;
    public float moveSpeed;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
 
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToPlayer();
	}

    // Find player direction
    Vector3 DirectionToPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 agentPosition = this.transform.position;

        Vector3 playerDirection = playerPosition - agentPosition;
        playerDirection.Normalize();

        return playerDirection;
    }

    // Move To Player
    void MoveToPlayer()
    {
        Vector3 moveVector = DirectionToPlayer() * moveSpeed * Time.deltaTime;

        this.transform.LookAt(player.transform);
        this.transform.position += moveVector;
    }
}
