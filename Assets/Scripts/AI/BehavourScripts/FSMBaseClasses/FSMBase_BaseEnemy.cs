using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMBase_BaseEnemy : StateMachineBehaviour
{
    public NavMeshAgent navAgent;
    public GameObject NPC;
    public GameObject player;
    public Vector3 targetPoint;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        player = NPC.GetComponent<BasicEnemyAIController>().GetPlayer();
        navAgent = NPC.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetDistanceToPlayer(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }

    void SetDistanceToPlayer(Animator animator)
    {       
        animator.SetFloat("DistanceToPlayer", Vector3.Distance(NPC.transform.position, player.transform.position));
    }
}
