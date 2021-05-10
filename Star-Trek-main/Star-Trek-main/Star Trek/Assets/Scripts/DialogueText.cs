using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    public GameObject continueButton;
    public AudioSource popSound;
    public Animator continueAnimator;
    public GameObject dialogueCanvas;
    public GameObject fadeImage;
    public static bool playDialogue = true;

    private IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public int pause;
    public static bool secondBool = true;
    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    public void NextSentence()
    {
        popSound.Play();
        continueAnimator.SetTrigger("OnClick");
        continueButton.SetActive(false);

        if (index == pause)
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueCanvas.SetActive(false);
            index ++;
            continueButton.SetActive(true);
            playDialogue = false;
        }
        else if (index < sentences.Length - 1)
        {
            playDialogue = true;
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            secondBool = false;
            playDialogue = false;
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueCanvas.SetActive(false);
            GameEvents.Instance.FadeImageIn(fadeImage, 7f);
            StartCoroutine(WaitForTime());
        }
    }
    public IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scene2");
    }
}
