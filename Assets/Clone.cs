using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : Entity
{

    public Vector2 spawnLocation;

    public PlayerActionSequence playerActions;

    private int actionNum = 0;

    private int frame = 0;

    private float startTime;
    private float time;

    private bool rightState;    // State of the keys, 0 means released and 1 means pressed
    private bool leftState;
    private bool upState;
    private bool downState;

    private bool grounded;

    private PlayerAction action;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        SyncWorldSettings();
        
        rb = this.GetComponent<Rigidbody2D>();
        spawnLocation = transform.position;
        action = playerActions.ReadAction(actionNum);
        actionNum++;
    }

    // Update is called once per frame
    void Update()
    {
        PerformAction();
        Move();
        frame++;
    }

    void PerformAction()
    {
        if (action != null)
        {
            if (frame >= action.time)
            {
                if (action.action == 0)
                {
                    if (action.key == right)
                    {
                        rightState = false;
                    }
                    if (action.key == left)
                    {
                        leftState = false;
                    }
                    if (action.key == up)
                    {
                        upState = false;
                    }
                    if (action.key == down)
                    {
                        downState = false;
                    }
                }
                else
                {
                    if (action.key == right)
                    {
                        rightState = true;
                    }
                    if (action.key == left)
                    {
                        leftState = true;
                    }
                    if (action.key == up)
                    {
                        upState = true;
                    }
                    if (action.key == down)
                    {
                        downState = true;
                    }
                }
                action = playerActions.ReadAction(actionNum);
                actionNum++;
            }
        }
        else
        {
            action = playerActions.ReadAction(actionNum);
        }
        
    }


    private void Move()
    {
        if (rightState)
        {
            //rb.AddForce(Vector2.right * accelSpeed);
            transform.Translate(Vector2.right * moveSpeed);
        }
        if (leftState)
        {
            //rb.AddForce(Vector2.left * accelSpeed);
            transform.Translate(Vector2.left * moveSpeed);
        }
        if (upState)
        {
            //rb.AddForce(Vector2.up * accelSpeed);
            transform.Translate(Vector2.up * moveSpeed);
        }
        if (downState)
        {
            //rb.AddForce(Vector2.down * accelSpeed);
            transform.Translate(Vector2.down * moveSpeed);
        }


        //if (!leftState && !rightState && !upState && !downState)
        //{
        //    if (rb.velocity.magnitude > 1)
        //    {
        //        rb.AddForce(-rb.velocity.normalized * accelSpeed);
        //    }
        //    else
        //    {
        //        rb.velocity = Vector2.zero;
        //    }

        //}

        //if (rb.velocity.magnitude > moveSpeed)
        //{
        //    rb.velocity = rb.velocity.normalized * moveSpeed;
        //}
    }
}
