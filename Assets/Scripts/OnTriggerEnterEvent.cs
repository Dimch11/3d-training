using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public UnityEvent win;

    private void OnTriggerEnter(Collider other)
    {
        win?.Invoke();
    }
}
