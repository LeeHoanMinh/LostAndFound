using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardUI : MonoBehaviour
{

    public void ClickOnBack()
    {
        MainSceneUI.instance.Scoreboard.SetActive(false);
        MainSceneUI.instance.MainBoard.SetActive(true);
        AudioManager.AM.Play("Button");
    }

    
}
