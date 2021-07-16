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
    //[SerializeField] private GameObject panel;

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

        //ArrayList stringList = new ArrayList();

        //int firstIndex = 0;
        //int length;
        //string newText = text;
        //foreach (char letter in textArray)
        //{
        //    Debug.Log(newText.IndexOf("."));
        //    if (newText.IndexOf(".") != -1)
        //    {
        //        Debug.Log("Does this ever happen");
        //        Debug.Log("firstIndex: " + firstIndex);
        //        Debug.Log("indexOf . : " + newText.IndexOf("."));
        //        if (newText.IndexOf(".") > firstIndex)
        //        {
        //            length = newText.IndexOf(".") - firstIndex;
        //            stringList.Add(text.Substring(firstIndex, length));
        //            firstIndex += length - 1;
        //            newText = newText.Substring(length + firstIndex);
        //        }
        //    }
        //}
        //Debug.Log(stringList.Count);

        //Debug.Log(text);

        int index = 1;
        //while (!dialogueFinished)
        //{
            //Debug.Log(index);
            //string str = (string)stringList[index];

	        //if (Input.GetKeyDown(KeyCode.Return)) 
	        //{
                //char[] strArray = str.ToCharArray();
                foreach (char letter in textArray)
                {
                    Debug.Log(letter);
                    textBox.text += letter;
                    if (!dialogueOn)
                    {
                        textBox.text = "";
                        yield break;
                    }
                    //eventAudioSource.pitch = Random.Range(0.3f, 1f);
                    //eventAudioSource.PlayOneShot(garbleClip, volume);
                    //if (index < stringList.Count-1) { index++; }
                    //else { dialogueFinished = true; }
                    yield return new WaitForSeconds(waitTime);

                //}
	        //}
        }

    }
}	
