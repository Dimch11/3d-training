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

    Movement movement;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (movement == null)
        {
            movement = animator.GetComponentInParent<Movement>();
        }

        var collider = movement.GetComponent<CapsuleCollider>();
        collider.height = jumpColliderHeight;
        collider.center = jumpColliderCenter;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var collider = movement.GetComponent<CapsuleCollider>();
        collider.height = colliderHeight;
        collider.center = colliderCenter;
    }
}
