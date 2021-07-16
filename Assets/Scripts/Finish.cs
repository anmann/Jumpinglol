using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private Rigidbody2D rb;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject panel;
    private Animator anim;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        rb = player.GetComponent<Rigidbody2D>();
        anim = panel.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();

            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            anim.SetTrigger("fade");
            Invoke("NextLevel", 1.2f);
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        rb.constraints = RigidbodyConstraints2D.None;
    }
}
