using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIL.Library;
public class Instruction : MonoBehaviour
{
    public GameObject[] instruction = new GameObject[6];
    public GameObject instruc;
    int cnt;
    private void Start()
    {
        cnt = 0;
        if(PlayerPrefs.GetInt("NewGame") == 0)
        {
            //pause game
            TimeManager.Instance.PauseGame();
            instruc.SetActive(true);
        }
    }

    public void Next()
    {
        if (cnt < 5)
        {
            instruction[cnt].SetActive(false);
            cnt++;
            instruction[cnt].SetActive(true);
        }
        else
            Skip();
    }

    public void Skip()
    {
        instruc.SetActive(false);
        //resume
        TimeManager.Instance.ResumeGame();
    }
}
