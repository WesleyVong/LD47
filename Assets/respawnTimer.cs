using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnTimer : MonoBehaviour
{

    private int respawnTime;
    public Text timerText;
    public bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        respawnTime = GameObject.Find("World").GetComponent<WorldSettings>().respawnTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        isRunning = true;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        for(int i = 0; i < respawnTime; i++)
        {
            if (timerText != null)
            {
                timerText.text = "Time until loop: " + (respawnTime - i);
            }
            yield return new WaitForSeconds(1);
      
        }
        foreach( GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (obj.GetComponent<Player>() != null)
            {
                obj.GetComponent<Player>().SpawnClone();
            }
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Item"))
        {
            if (obj.GetComponent<ItemHandler>() != null)
            {
                obj.GetComponent<ItemHandler>().Respawn();
            }
        }
        StartCoroutine(Timer());
    }
}
