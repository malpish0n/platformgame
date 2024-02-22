using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text text;
    public string[] sentences;
    private int index;
    public float Typing_speed;
    bool is_Fulltext;
    public Animation FadeIn;

    private void Start()
    {
        FadeIn.Play();
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(Typing_speed);
        }
    }
    
    void NextSentence()
    {
        FadeIn.Play();
        is_Fulltext = false;
        if(index < sentences.Length-1)
        {
            index++;
            text.text = "";
            StartCoroutine(Type());
        }
        else
        {
            text.text = "";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_Fulltext)
        {
            NextSentence();
        }

        if(text.text == sentences[index])
        {
            is_Fulltext = true;
        }
    }
}
