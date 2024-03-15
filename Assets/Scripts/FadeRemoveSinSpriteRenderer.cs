using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeRemoveSinSpriteRenderer : StateMachineBehaviour
{
    public float fadeTime = 0.5f;
    private float timeElapsed = 0f;
    private GameObject objRemove;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed = 0;
        objRemove = animator.gameObject;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= fadeTime)
        {
            Destroy(objRemove);
        }
    }
}
