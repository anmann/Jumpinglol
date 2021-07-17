using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : MonoBehaviour
{
    [SerializeField] private string text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("OK");
            DialogueBox.dialogueOn = true;
            DialogueBox.text = text;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            DialogueBox.dialogueOn = false;
            DialogueBox.dialogueStarted = false;
            DialogueBox.textBox.text = "";
        }
    }
}
