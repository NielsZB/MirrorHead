using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerResponse : MonoBehaviour
{

    [SerializeField] UnityEvent response;

    public void Activate()
    {
        response.Invoke();
    }
}
