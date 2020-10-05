using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckList : MonoBehaviour
{
    public Sprite check;
    public Sprite cross;

    public void setCheck()
    {
        GetComponent<Image>().sprite = check;
    }
    public void setCross()
    {
        GetComponent<Image>().sprite = cross;
    }
}
