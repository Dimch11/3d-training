using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public UnityEvent OnJump;

    public float forwardSpeed;
    public float leftRightSpeed;

    public float jumpHeight;

    [Header("Internal")]
    public Rigidbody rb;

    [Header("Ground check")]
    public Transform groundCheckFrom;
    public Transform groundCheckTo;
    public float groundCheckRadius;
    public LayerMask groundMask;

    float leftOrRightKeyPressed;
    bool isGrounded;

    public bool IsGrounded => isGrounded;

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        JumpIfSpacePressed();
        CheckForHorizontalAxis();
        CheckIfGrounded();
    }

    private void JumpIfSpacePressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    private void CheckForHorizontalAxis()
    {
        leftOrRightKeyPressed = Input.GetAxis("Horizontal");
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckCapsule(groundCheckFrom.position, groundCheckTo.position, groundCheckRadius, groundMask);
    }

    

    #region Move

    void Move()
    {
        var offset = new Vector3(CalcXOffset(), 0, CalcZOffset());
        rb.MovePosition(transform.position + offset);
    }

    private float CalcZOffset()
    {
        return -leftOrRightKeyPressed * leftRightSpeed * Time.fixedDeltaTime;
    }

    float CalcXOffset()
    {
        return forwardSpeed * Time.fixedDeltaTime;
    }

    #endregion


    #region Jump

    void Jump()
    {
        rb.velocity = new Vector3(0, CalcSpeedForJump(), 0);
        OnJump?.Invoke();
    }

    float CalcSpeedForJump()
    {
        return Mathf.Sqrt(jumpHeight * 2f * -Physics.gravity.y);
    }

    #endregion
}
