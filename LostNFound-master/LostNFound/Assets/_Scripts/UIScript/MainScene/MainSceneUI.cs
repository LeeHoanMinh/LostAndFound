using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public static MainSceneUI instance;
    public GameObject PopUp,LockLayer,Scoreboard,MusicOn,MusicOff,MainBoard;

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.GetInt("MusicVolume") == 1)
            SetMusicOff();
    }
    public void ClickOnPlay()
    {
        PlayerPrefs.SetInt("NewGame", 0);
        AudioManager.AM.Play("Button");
        SceneManager.LoadScene("GamePlay");
    }

    public void ClickOnContinue()
    {
        LockScreen();
        //Set Info

        PlayerPrefs.SetInt("NewGame", 1);
        SceneManager.LoadScene("GamePlay");
        AudioManager.AM.Play("Button");
    }

    public void ClickOnScoreboard()
    {
        MainBoard.SetActive(false);
        Scoreboard.SetActive(true);
        AudioManager.AM.Play("Button");
    }

    public void SetMusicOn()
    {
        MusicOn.SetActive(true);
        MusicOff.SetActive(false);
        AudioManager.AM.TurnOnMusic();
        AudioManager.AM.TurnOnSound();
        AudioManager.AM.Play("Button");
    }

    public void SetMusicOff()
    {
        MusicOn.SetActive(false);
        MusicOff.SetActive(true);
        AudioManager.AM.TurnOffMusic();
        AudioManager.AM.TurnOffSound();
        AudioManager.AM.Play("Button");
    }

    public void LockScreen()
    {
        LockLayer.SetActive(true);
    }
}
