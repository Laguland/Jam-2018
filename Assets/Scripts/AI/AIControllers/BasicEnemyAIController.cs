using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyAIController : Character {

	GameObject player;
	NavMeshAgent agent;
    GameObject HUD;
	private Animator anim;
	private float dmgPerSecond = 2f;

	private bool attacking;

	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		base.currentHealth = base.baseHealth;
        HUD = GameObject.Find("HUDManager");
	}

	public void StartAttack() {
		attacking = true;
		StartCoroutine("Attack");
	}

	public void StopAttack() {
		attacking = false;
	}

	private IEnumerator Attack() {
        yield return new WaitForSeconds(1f);
        if (attacking)
        {
            player.GetComponent<Player>().GetDamage(10f);
            StartCoroutine("Attack");
        }
    }
	
	public GameObject GetPlayer() {
		return player;
	}

	public override void GetDamage(float amount) {
		base.currentHealth -= amount;
        anim.SetFloat("AgentLife", currentHealth);

        if(currentHealth <= 0)
        {
            Death();
        }
	}

	public override void Death() {
        player.GetComponent<LightProgress>().DecreaseEnemyCounter();
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<MeshCollider>().enabled = false;
        HUD.GetComponent<HUDManager>().UpdateMonsterCount();
    }
}