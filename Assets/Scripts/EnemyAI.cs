using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : Character {

	GameObject player;
	NavMeshAgent agent;

	private Animator anim;
	
	
	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		agent.SetDestination(player.transform.position);
		//MoveToPlayer();
	}

	// Find player direction
	Vector3 DirectionToPlayer() {
		Vector3 playerPosition = player.transform.position;
		Vector3 agentPosition = this.transform.position;

		Vector3 playerDirection = playerPosition - agentPosition;
		playerDirection.Normalize();

		return playerDirection;
	}

	// Move To Player
	void MoveToPlayer() {
		Vector3 moveVector = DirectionToPlayer() * moveSpeed * Time.deltaTime;

		this.transform.LookAt(player.transform);
		this.transform.position += moveVector;
	}

	private void OnCollisionEnter(Collision other) {
		if (other.transform.tag.Equals("Player")) {
			anim.SetBool("attack", true);
			anim.SetBool("walking", false);
		}
	}

	private void OnCollisionStay(Collision other) {
		if (other.transform.tag.Equals("Player")) {
			if (!anim.GetBool("attack"))
				anim.SetBool("attack", true);
		}
	}

	private void OnCollisionExit(Collision other) {
		if (other.transform.tag.Equals("Player"))
			anim.SetBool("attack", false);
			anim.SetBool("walking", true);
	}

	override public void Death() { }
}
