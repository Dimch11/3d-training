using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    public float forwardSpeed;
    public float leftRightSpeed;

    [Header("Internal")]
    public Rigidbody rb;


    float leftOrRight;

    private void Start()
    {

    }


    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Jump();
        leftOrRight = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        var offset = new Vector3(forwardSpeed * Time.fixedDeltaTime, 0, -leftOrRight * leftRightSpeed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + offset);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, Mathf.Sqrt(2 * 2f * 9.81f), 0);
        }
    }
}
