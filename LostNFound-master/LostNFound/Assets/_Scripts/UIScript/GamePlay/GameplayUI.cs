using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DIL.Library;


public class GameplayUI : MonoBehaviour
{
    public static GameplayUI instance;
    public GameObject PauseLayer;
    public GameObject EndLayer;

    public Text day;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameEventHandler.Instance.OnLoseGame += EndScene;
    }
    public void ClickOnRoll()
    {
        FamilyActivityManager.Instance.Roll();
        AudioManager.AM.Play("Roll");
    }
    public void ClickOnPause()
    {
        PauseLayer.SetActive(true);
        TimeManager.Instance.PauseGame();
        AudioManager.AM.Play("Button");
    }

    public void ClickOnExit()
    {
        TimeManager.Instance.ResumeGame();
        SceneManager.LoadScene("MainMenu");
        AudioManager.AM.Play("Button");
    }

    public void ClickOnBack()
    {
        TimeManager.Instance.ResumeGame();
        PauseLayer.SetActive(false);
        AudioManager.AM.Play("Button");
    }
    public void EndScene()
    {
        EndLayer.SetActive(true);
        AudioManager.AM.Play("LoseGame");
        day.text = TimeManager.Instance.CurDay.ToString();
        ScoreboardManager.Instance.AddResult(TimeManager.Instance.CurDay);
    }

}
