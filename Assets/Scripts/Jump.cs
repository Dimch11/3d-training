using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : StateMachineBehaviour
{
    [Header("Collider")]
    public Vector3 colliderCenter = new(0, -0.1619171f, 0);
    public float colliderHeight = 1.676166f;
    public Vector3 jumpColliderCenter = new(0, 0.1542305f, 0);
    public float jumpColliderHeight = 1.043871f;

    [Header("Ground check")]
    public Vector3 groundCheckPos = new(0, -1, 0);
    public Vector3 jumpGroundCheckPos = new(0, -0.34f, 0);

    Movement movement;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (movement == null)
        {
            movement = animator.GetComponentInParent<Movement>();
        }

        var collider = movement.GetComponent<CapsuleCollider>();
        collider.height = jumpColliderHeight;
        collider.center = jumpColliderCenter;
        movement.groundCheck.localPosition = jumpGroundCheckPos;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var collider = movement.GetComponent<CapsuleCollider>();
        collider.height = colliderHeight;
        collider.center = colliderCenter;
        movement.groundCheck.localPosition = groundCheckPos;
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
