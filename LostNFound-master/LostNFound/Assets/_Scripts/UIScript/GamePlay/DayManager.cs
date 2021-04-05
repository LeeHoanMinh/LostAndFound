using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public Text text;
    public void DayUpdate(int days)
    {
        text.text = "Day " + days.ToString();
    }
}
