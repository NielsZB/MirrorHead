using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    enum Mode
    {
        Enter,
        Exit,
        ExitAndEnter
    }

    [SerializeField] Mode TriggerEventAt = Mode.Enter;

    [SerializeField] GameEvent eventAtEnter = null;
    [SerializeField] GameEvent eventAtExit = null;

    private void OnTriggerEnter(Collider other)
    {
        if(TriggerEventAt == Mode.Enter || TriggerEventAt == Mode.ExitAndEnter)
        {
            eventAtEnter.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(TriggerEventAt == Mode.Exit || TriggerEventAt == Mode.ExitAndEnter)
        {
            eventAtExit.Activate();
        }
    }
}
