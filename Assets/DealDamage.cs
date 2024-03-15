using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : StateMachineBehaviour
{
    public AudioClip audioClip;
    public bool playOnenter= false, playOnExit=false,playAfterDelay=false;

    private float timeSinceEntered=0;
    private bool hasDealayedSound=false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (playOnenter)
       {
        AudioSource.PlayClipAtPoint(audioClip,animator.transform.position,2);
       }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (playOnExit)
       {
        AudioSource.PlayClipAtPoint(audioClip,animator.transform.position,2);
       }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
