using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int apples = 0;
    public static bool speedUp = false;

    private float speedTime = 5f;

    [SerializeField] private Text applesText;
    [SerializeField] private Text speedUpText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        applesText.text = "Apples: " + apples;
        if (speedUpText != null) speedUpText.text = "";
    }

    private void Update()
    {
        if (PlayerLife.hasDied)
        {
            speedUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            apples++;
            applesText.text = "Apples: " + apples;
        }

        if (collision.gameObject.CompareTag("Speed"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            speedUpText.text = "Zoooooom";
            StartCoroutine(SpeedDuration());
            speedUp = true;
        }
    }

    private IEnumerator SpeedDuration()
    {
        yield return new WaitForSeconds(speedTime);
        speedUp = false;
        speedUpText.text = "";
    }
}
