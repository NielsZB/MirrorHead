using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    List<GameEventReceiver> listeners = new List<GameEventReceiver>();
    [SerializeField] bool debug = false;

    [ContextMenu("Activate listeners")]
    public void Activate()
    {
        if (listeners.Count != 0)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                if (debug)
                {
                    Debug.Log($"{listeners[i].name} is listening to {name}.");
                }
                else
                {
                    listeners[i].OnEventActivate();
                }
            }
        }
    }

    public void RegisterListener(GameEventReceiver listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnregisterListener(GameEventReceiver listener)
    {
        listeners.Remove(listener);
    }
}
