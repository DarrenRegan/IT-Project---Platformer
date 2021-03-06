﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneBehavior : StateMachineBehaviour
{
    public int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);

        // randomly goes into either idle or jump mode in stage one
        if (rand == 0)
            animator.SetTrigger("Idle");
        else
            animator.SetTrigger("Jump");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
