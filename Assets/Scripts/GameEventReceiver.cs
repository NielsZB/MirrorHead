using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventReceiver : MonoBehaviour
{
    [SerializeField,Tooltip("Can be used even though left empty.")]
    GameEvent respondTo = null;
    [SerializeField] float delay = 0f;
    [SerializeField] UnityEvent response = null;

    WaitForSeconds waitForDelay;
    void OnEnable()
    {
        if (respondTo != null)
        {
            respondTo.RegisterListener(this);
        }

        if (delay != 0)
        {
            waitForDelay = new WaitForSeconds(delay);
        }
    }

    void OnDisable()
    {
        if (respondTo != null)
        {
            respondTo.UnregisterListener(this);
        }
    }

    public void OnEventActivate()
    {
        if (delay == 0)
        {
            response.Invoke();
        }
        else
        {
            StartCoroutine(WaitBeforeResponse());
        }
    }

    public void Activate()
    {
        OnEventActivate();
    }

    IEnumerator WaitBeforeResponse()
    {
        yield return waitForDelay;

        response.Invoke();
    }
}