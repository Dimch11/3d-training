using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public List<Collider> colliders;
    List<Rigidbody> rigidbodies;

    void Start()
    {
        GetRBs();

        TurnOffRagdollColliders();
        TurnOffRagdollRBs();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DoRagdoll();
        }
    }

    public void DoRagdoll()
    {
        TurnOnRagdollColliders();
        TurnOnRagdollRBs();
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<Movement>().enabled = false;
        GetComponentInChildren<Animator>().enabled = false;
    }

    void TurnOnRagdollColliders()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = true;
        }
    }

    void TurnOffRagdollColliders()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
    }

    void TurnOffRagdollRBs()
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    void TurnOnRagdollRBs()
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }

    void GetRBs()
    {
        rigidbodies = new List<Rigidbody>();

        foreach (var collider in colliders)
        {
            rigidbodies.Add(collider.GetComponent<Rigidbody>());
        }
    }
}
