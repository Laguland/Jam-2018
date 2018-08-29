using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : FSMBase_BaseEnemy
{
    public bool bFixedWaitTime = false;
    public float fixedWaitTime;
    public float randomWaitTimeMin = 1.0f;
    public float randomWaitTimeMax = 5.0f;

    private float WaitTime;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (bFixedWaitTime)
        {
            WaitTime = fixedWaitTime;
        }
        else
        {
            WaitTime = Random.Range(randomWaitTimeMin,randomWaitTimeMax);
            Debug.Log("Wait Time: " + NPC.name + ", " + WaitTime);
        }
        timer = 0.0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (timer > WaitTime)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
