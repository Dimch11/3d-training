using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorHelper : MonoBehaviour
{
    public Movement movement;
    public Animator animator;

    void Update()
    {
        animator.SetBool("isGrounded", movement.IsGrounded);
    }
}
