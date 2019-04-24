using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTwoBehavior : StateMachineBehaviour
{
    public int rand;
    public Animator anim;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);

        // randomly goes into either running or attacking mode in stage two
        if (rand == 0)
            anim.SetTrigger("Run");
        else
            anim.SetTrigger("Attack");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
