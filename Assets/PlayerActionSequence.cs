using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionSequence
{
    private List<PlayerAction> actions = new List<PlayerAction>();

    public PlayerActionSequence()
    {

    }

    public void AddAction(int frame, KeyCode key, int action)
    {
        actions.Add(new PlayerAction(frame, key, action));
    }

    public PlayerAction ReadAction(int index)
    {
        if (index < actions.Count)
        {
            return actions[index];
        }
        else
        {
            return null;
        }
    }
}
