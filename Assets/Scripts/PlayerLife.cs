using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    // Set the max bounds to 0 if not relevant
    [SerializeField] private bool boundsDeath;
    [SerializeField] private float yBoundsMin;
    [SerializeField] private float yBoundsMax;
    [SerializeField] private float xBoundsMin;
    [SerializeField] private float xBoundsMax;

    [SerializeField] private AudioSource deathSoundEffect;
    private bool deathAnimRan;

    public static bool hasDied;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deathAnimRan = false;
        hasDied = false;
    }

    private void Update()
    {
        if (boundsDeath)
        {
            if (yBoundsMin != 0 && transform.position.y < yBoundsMin && !deathAnimRan)
            {
                Death();
                deathAnimRan = true;
            }
            else if (yBoundsMax != 0 && transform.position.y > yBoundsMax && !deathAnimRan)
            {
                Death();
                deathAnimRan = true;
            }
            else if (xBoundsMin != 0 && transform.position.x < xBoundsMin && !deathAnimRan)
            {
                Death();
                deathAnimRan = true;
            }
            else if (xBoundsMax != 0 && transform.position.x > xBoundsMax && !deathAnimRan)
            {
                Death();
                deathAnimRan = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Death();
        }
    }

    public void Death()
    {
        anim.SetTrigger("death");
        deathSoundEffect.Play();
        hasDied = true;
        rb.bodyType = RigidbodyType2D.Static;
        ItemCollector.apples = 0;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
