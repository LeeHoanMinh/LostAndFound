using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpEnergyFx : MonoBehaviour
{
    public Color color1, color2;
    public Text text;
    public Animation anim;

    public void PlayEffect(int amount)
    {
        if (amount < 0) 
        {
            text.text = amount.ToString();
            text.color = color1;
        }
        else
        {
            text.text = "+" + amount.ToString();
            text.color = color2;
        }
        anim.Play();
    }

}
