using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeRemove : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    
    public float fadeTime= 0.5f;
    public float timeElapsed=0f;
    SpriteRenderer spriteRenderer;

    GameObject objRemove;
    Color startColor;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timeElapsed=0;
       spriteRenderer=animator.GetComponent<SpriteRenderer>();
        startColor=spriteRenderer.color;
       objRemove= animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
       timeElapsed+=Time.deltaTime;

       float newAlpha = startColor.a*(1-timeElapsed/fadeTime);

       spriteRenderer.color= new Color(startColor.r,startColor.g,startColor.b,newAlpha);

       if (timeElapsed>fadeTime)
       {
             if (objRemove.gameObject.tag=="Player")
            {
                  SceneManager.LoadSceneAsync("Nivel1");
            }
            Destroy(objRemove);
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
