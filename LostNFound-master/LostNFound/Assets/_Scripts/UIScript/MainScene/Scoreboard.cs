using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text[] days = new Text[4];
    private void Start()
    {         
        for (int i = 0; i < 4; i++)
            days[i].text = "";
        List<int> list = ScoreboardManager.Instance.GetTopScore();
        for (int i = 0; i < list.Count; i++)
            days[i].text = list[i].ToString() + " Days";
    }

    
}
