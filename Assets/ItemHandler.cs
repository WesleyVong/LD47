using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite img;
    public bool entityDetected = false;
    public bool playerDetected = false;
    public bool disablePickup = false;

    AudioSource audioSource;

    private void Start()
    {
        if (img == null)
        {
            img = GetComponent<SpriteRenderer>().sprite;
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Respawn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            entityDetected = true;
            if (collision.gameObject.name == "Player")
            {
                playerDetected = true;
            }
        }
        if (!disablePickup)
        {
            if (playerDetected)
            {
                audioSource.Play();
            }
            GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            entityDetected = false;
            if(collision.gameObject.name == "Player")
            {
                playerDetected = false;
            }
        }
    }
}
