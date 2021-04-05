using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopUpUI : MonoBehaviour
{
    public void ClickOnYes()
    {
        SceneManager.LoadScene("GamePlay");
        AudioManager.AM.Play("Button");
    }

    public void ClickOnNo()
    {
        MainSceneUI.instance.PopUp.SetActive(false);
        AudioManager.AM.Play("Button");
    }
}
