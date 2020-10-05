using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction
{
    public float time;                 // Time this action is performed
    public KeyCode key;                  // The key press recorded
    public int action;           // Whether the key is pressed or released, 1 = press, 0 = release

    public PlayerAction()
    {
        time = 0;
        key = KeyCode.None;
        action = 0;
    }
    public PlayerAction(int f, KeyCode k, int a)
    {
        time = f;
        key = k;
        action = a;
        
    }

    public override string ToString()
    {
        return "Time: " + time + ", Key: " + key + ", Action: " + action;
    }
}
