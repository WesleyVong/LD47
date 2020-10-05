using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    public Vector2 spawnLocation;

    public GameObject clone;

    public PlayerActionSequence playerActions;

    private int maxClones;

    private float time;

    private int frame = 0;

    private GameObject spawnedClone;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        maxClones = GameObject.Find("World").GetComponent<WorldSettings>().maxClones;
        SyncWorldSettings();
        rb = this.GetComponent<Rigidbody2D>();
        spawnLocation = transform.position;
        playerActions = new PlayerActionSequence();
    }

    // Update is called once per frame
    void Update()
    {
        RecordKey(right);
        RecordKey(left);
        RecordKey(up);
        RecordKey(down);

        frame++;


        if (Input.GetKey(right))
        {
            //rb.AddForce(Vector2.right * accelSpeed);
            transform.Translate(Vector2.right * moveSpeed);
        }
        if (Input.GetKey(left))
        {
            //rb.AddForce(Vector2.left * accelSpeed);
            transform.Translate(Vector2.left * moveSpeed);
        }
        if (Input.GetKey(up))
        {
            //rb.AddForce(Vector2.up * accelSpeed);
            transform.Translate(Vector2.up * moveSpeed);
        }
        if (Input.GetKey(down))
        {
            //rb.AddForce(Vector2.down * accelSpeed);
            transform.Translate(Vector2.down * moveSpeed);
        }


        //if (!Input.GetKey(left) && !Input.GetKey(right) && !Input.GetKey(up) && !Input.GetKey(down))
        //{
        //    if (rb.velocity.magnitude > 1)
        //    {
        //        rb.AddForce(-rb.velocity.normalized * accelSpeed);
        //    } else
        //    {
        //        rb.velocity = Vector2.zero;
        //    }
            
        //}

        //if (rb.velocity.magnitude > moveSpeed)
        //{
        //    rb.velocity = rb.velocity.normalized * moveSpeed;
        //}
    }

    private void RecordKey(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            playerActions.AddAction(frame, key, 1);
        }
        else if (Input.GetKeyUp(key))
        {
            playerActions.AddAction(frame, key, 0);
        }
    }

    public void SpawnClone()
    {
        spawnedClone = Instantiate(clone, spawnLocation, transform.rotation);
        spawnedClone.name = "Clone";
        spawnedClone.GetComponent<Clone>().playerActions = this.playerActions;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("World").GetComponent<Game_Handler>().Lost();
        }
    }
}
