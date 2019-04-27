using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour
{
    [SerializeField]
    GameObject fireball;

    float fireRate;
    float nextFire;

    Vector2 fireballPos;

    public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Time.time > nextFire)
        {
           //Instantiate(fireball, transform.position, Quaternion.identity);
           nextFire = Time.time + fireRate;
        }
    }

    
}
