using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject nextButton;


    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            nextButton.SetActive(true);
        }
        print(nextButton);
    }
    void Start()
    {
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }

    public void NextSentence()
    {
        print(nextButton);
        nextButton.SetActive(false);
        if (index < sentences.Length - 1)
        {

            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            nextButton.SetActive(false);
        }
        
    }


}
