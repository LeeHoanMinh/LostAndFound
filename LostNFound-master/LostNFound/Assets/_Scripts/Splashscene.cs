using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splashscene : MonoBehaviour
{
    public Image splashScene;
    public GameObject splashNext,next1,next2;
    IEnumerator splash()
    {
        Color color = splashScene.color;
        while(color.a < 1)
        {
            color.a += 0.01f;
            splashScene.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        splashScene.gameObject.SetActive(false);
        splashNext.SetActive(true);

        yield return null;
    }

    private void Start()
    {
        StartCoroutine(splash());
    }

    public void Next1()
    {
        splashNext.SetActive(false);
        next1.SetActive(true);
    }

    public void Next2()
    {
        next1.SetActive(false);
        next2.SetActive(true);
    }

    public void Next3()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
