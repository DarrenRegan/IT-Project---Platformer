using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageThreeBehavior : StateMachineBehaviour
{
    public int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 3);

        // randomly goes into either idle or jump mode in stage one
        if (rand == 0)
            animator.SetTrigger("Idle");
        else if (rand == 1)
            animator.SetTrigger("Attack");
        else
            animator.SetTrigger("Fly");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
