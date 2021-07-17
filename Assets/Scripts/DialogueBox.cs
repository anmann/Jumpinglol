using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public static bool dialogueOn = false;
    public static bool dialogueFinished = false;
    private CanvasGroup canv;
    public static string text;
    [SerializeField] private GameObject trigger;
    [SerializeField] private float waitTime;
    public static UnityEngine.UI.Text textBox;

    [SerializeField] private UnityEngine.UI.Text textBoxEstablish;

    public static bool dialogueStarted = false;

    private void Start()
    {
        canv = GetComponent<CanvasGroup>();
        textBox = textBoxEstablish;
    }

    private void Update()
    {
        if (!dialogueOn)
        {
            canv.alpha = 0;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                canv.alpha = 0;
                dialogueOn = false;
                textBox.text = "";
            }

            canv.alpha = 1;

            if (!dialogueStarted)
            {
                StartCoroutine(DisplayText(text, waitTime));
                dialogueStarted = true;
            }
            
        }
    }

    private IEnumerator DisplayText(string text, float waitTime)
    {
        yield return new WaitForSeconds(0.2f);
        char[] textArray = text.ToCharArray();

        foreach (char letter in textArray)
        {
            Debug.Log(letter);
            textBox.text += letter;
            if (!dialogueOn)
            {
                textBox.text = "";
                yield break;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}	
