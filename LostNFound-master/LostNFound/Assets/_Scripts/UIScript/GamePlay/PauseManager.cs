using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DIL.Library;

public class PauseManager : MonoBehaviour
{
    public void ClickOnContinue()
    {
        GameplayUI.instance.PauseLayer.SetActive(false);
        TimeManager.Instance.ResumeGame();
    }

    public void ClickOnExit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
