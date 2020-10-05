using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Handler : MonoBehaviour
{
    public GameObject goal;
    public GameObject winPanel;
    public GameObject lostPanel;


    List<GameObject> items;
    List<GameObject> checkList;
    GameObject timeMachine;

    string goalString = "Goal: \n Get Battery from Garage \n Get Screwdriver from Shed \n Get Hammer from Backyard \n Return items to the time machine";
    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.Find("World").GetComponent<WorldSettings>().items;
        checkList = GameObject.Find("World").GetComponent<WorldSettings>().checkList;
        timeMachine = GameObject.Find("World").GetComponent<WorldSettings>().timeMachine;
        GetComponent<respawnTimer>().StartTimer();
        goal.GetComponent<TextTyper>().TypeText(goalString, 0.01f, 99999);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
                if (items[i].GetComponent<ItemHandler>().playerDetected)
                {
                    checkList[i].GetComponent<CheckList>().setCheck();
                    items.RemoveAt(i);
                    checkList.RemoveAt(i);
                }
            }
            
        }
        if (items.Count == 0)
        {
            if (timeMachine.GetComponent<ItemHandler>().playerDetected)
            {
                checkList[0].GetComponent<CheckList>().setCheck();
                Win();
            }
            
        }
    }

    public void Lost()
    {
        lostPanel.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().enabled = false;
        StartCoroutine(Quit());
    }

    public void Win()
    {
        winPanel.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().enabled = false;
        StartCoroutine(Quit());
    }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);

    }

    void Rules()
    {

    }
}
