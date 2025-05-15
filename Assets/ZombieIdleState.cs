using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : StateMachineBehaviour
{
    float timer;
    public float idleTime = 0f;

    Transform player;

    public float detectionAreaRadius = 18f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // --- Transition to Patrol State --- //

       timer += Time.deltaTime;
       if (timer > idleTime)
       {
            animator.SetBool("isIdle", false);
       }

       // --- Transition to Chase State --- //

       float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
       if (distanceToPlayer < detectionAreaRadius)
       {
            animator.SetBool("isChasing", true);
       }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
