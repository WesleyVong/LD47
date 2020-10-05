using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    private float degreePerTick;

    private void Start()
    {
        degreePerTick = 360 / GameObject.Find("World").GetComponent<WorldSettings>().respawnTime;
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        while (true)
        {
            if (GameObject.Find("World").GetComponent<respawnTimer>().isRunning)
            {
                transform.Rotate(0, 0, -degreePerTick);
            }
            yield return new WaitForSeconds(1);
            
        }
        
    }
}
