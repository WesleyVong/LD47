using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSettings : MonoBehaviour
{
    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;

    public float moveSpeed;
    public float accelSpeed;

    public int respawnTime;
    public int maxClones;

    public List<GameObject> items; // The items the player has to retrieve
    public List<GameObject> checkList;
    public GameObject timeMachine;
}
