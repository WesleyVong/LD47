using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float moveSpeed;
    protected float accelSpeed;

    protected KeyCode right;
    protected KeyCode left;
    protected KeyCode up;
    protected KeyCode down;

    //public abstract void Respawn();

    public virtual void SyncWorldSettings()
    {
        WorldSettings ws = GameObject.Find("World").GetComponent<WorldSettings>();
        if (ws != null)
        {
            right = ws.right;
            left = ws.left;
            up = ws.up;
            down = ws.down;
            moveSpeed = ws.moveSpeed;
            accelSpeed = ws.accelSpeed;
        }
    }
}
