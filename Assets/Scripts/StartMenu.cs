using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private Animator anim;
    private Animation crosshair;
    [SerializeField] private GameObject panel;

    private void Start()
    {
        anim = panel.GetComponent<Animator>();
        crosshair = panel.GetComponent<Animation>();
    }

    public void StartGame()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        anim.SetTrigger("button");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
