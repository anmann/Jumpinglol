using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int apples = 0;
    //private bool speedUp = false;

    [SerializeField] private Text applesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        applesText.text = "Apples: " + apples;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            // Removes item from screen
            Destroy(collision.gameObject);
            apples++;
            applesText.text = "Apples: " + apples;
        }
        //if (collision.gameObject.CompareTag("Speed"))
        //{
        //    collectionSoundEffect.Play();
        //    Destroy(collision.gameObject);
            
        //}
    }
}
