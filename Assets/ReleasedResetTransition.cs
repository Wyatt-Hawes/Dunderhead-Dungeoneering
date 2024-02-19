using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasedResetTransition : StateMachineBehaviour
{
    public string targetStateName = "Normal";

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //    if (animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(targetStateName))
    //     {
    //         Debug.Log("Normal, Selected = False");
    //         animator.state("Selected");
    //     }
    // }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the parameters when the animation ends
       // animator.SetBool("IsPressed", false);

        // animator.SetBool("PointerUp", false);
        // animator.SetBool("Highlighted", false);
        // animator.SetBool("Selected", false);
        // Debug.Log("Resetting parameters");
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
