using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour
{
    float textDelay;
    float endDelay;
    Queue<string> words = new Queue<string>();

    AudioSource audioSource;

    public Text text;
    public bool isFinished = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TypeText()
    {
        if (words.Count > 0)
        {
            StartCoroutine(Type());
        }
    }

    public void TypeText(string str)
    {
        words.Enqueue(str);
        textDelay = 0.1f;
        endDelay = -1;
        StartCoroutine(Type()) ;
    }

    public void TypeText(string str, float d)
    {
        words.Enqueue(str);
        textDelay = d;
        endDelay = -1;
        StartCoroutine(Type());
    }

    public void TypeText(string str, float d, float ed)
    {
        words.Enqueue(str);
        textDelay = d;
        endDelay = ed;
        StartCoroutine(Type());
    }

    public void QueueText(string str)
    {
        words.Enqueue(str);
    }

    public void ClearText()
    {
        text.text = "";
    }

    IEnumerator Type()
    {
        isFinished = false;
        ClearText();
        int queueLength = words.Count;
        for (int j = 0; j < queueLength; j++)
        {
            string word = words.Dequeue();
            for (int i = 0; i <= word.Length; i++)
            {
                if (audioSource != null)
                {
                    audioSource.Play();
                }
                yield return new WaitForSeconds(textDelay);
                text.text = word.Substring(0, i);
            }
            if (endDelay >= 0)
            {
                yield return new WaitForSeconds(endDelay);
                ClearText();
            }
        }
        isFinished = true;
    }
}
