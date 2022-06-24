using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipCollider : MonoBehaviour
{
    public Ragdoll ragdoll;

    private void OnTriggerEnter(Collider other)
    {
        ragdoll.DoRagdoll();
    }
}
