using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The character "/" is used to split up the dialouge into multiple panels
// Ex: "Hello there./ How are you?/" will print
// "Hello there." and "How are you?" on different panels
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

    public static bool dialogueInterrupted = false;

    public bool finishedDisplaying = false;

    public static int index;

    public static ArrayList stringList;

    private void Start()
    {
        canv = GetComponent<CanvasGroup>();
        textBox = textBoxEstablish;
        stringList = new ArrayList();
        index = 0;
    }

    private void Update()
    {
        if (!dialogueOn)
        {
            canv.alpha = 0;
        }
        else
        {
            canv.alpha = 1;

            if (Input.GetKeyDown(KeyCode.Return) && dialogueFinished)
            {
                canv.alpha = 0;
                dialogueOn = false;
                textBox.text = "";
            }

            if (!dialogueStarted)
            {
                DialogueStart();
            }

            if (!dialogueFinished)
            {
                WhileDialogueRunning();
            }
        }
    }

    private void DialogueStart()
    {
        CutText(text, stringList);

        StartCoroutine(DisplayText((string)stringList[index]));
        index++;

        dialogueStarted = true;
    }

    private void WhileDialogueRunning()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index >= stringList.Count)
            {
                dialogueOn = false;
                canv.alpha = 0;
                textBox.text = "";
                dialogueFinished = true;
            }
            else
            {
                string s = (string)stringList[index];
                textBox.text = "";
                if (!finishedDisplaying) { dialogueInterrupted = true; }

                StartCoroutine(DisplayText(s));
                index++;
            }
        }
    }

    private void CutText(string text, ArrayList stringList)
    {
        int length = text.IndexOf("/");
        stringList.Add(text.Substring(0, length));

        if (text.Length > text.IndexOf("/") && text.Length > length + 2)
        {
            CutText(text.Substring(length + 2), stringList);
        }
    }

    private IEnumerator DisplayText(string text)
    {
        finishedDisplaying = false;
        yield return new WaitForSeconds(0.15f);
        char[] textArray = text.ToCharArray();

        foreach (char letter in textArray)
        { 
            textBox.text += letter;
            if (!dialogueOn || dialogueInterrupted)
            {
                dialogueInterrupted = false;
                textBox.text = "";
                yield break;
            }

            yield return new WaitForSeconds(waitTime);
        }
        finishedDisplaying = true;
    }
}	
