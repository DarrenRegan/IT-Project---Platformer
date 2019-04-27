using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehavior : StateMachineBehaviour
{
    float maxVertDist = 10;
    float maxHoriDist = 30;
    Vector2 origin;
    float speed = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

 

}
