using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type2 : MonoBehaviour
{
    public Text title;
    public Image img;
    public Text healthplus,healthminus;
    public Text energy;
    public GameObject[] icons = new GameObject[4];
    public GameObject oricon;
    public GameObject groupplus,groupminus;

    public FamilyActivity test;
    public void SetInfo(FamilyActivity card)
    {

        title.text = card.Title;

        int health = GetHealthPlus(card);
        healthplus.text = '+' + health.ToString();
        energy.text = card.EnergyCount.ToString();
        SetGroupPlus(card);
        health = GetHealthMinus(card);
        healthminus.text = health.ToString();
        SetGroupMinus(card);
        print(card.Sprite);
        img.sprite = card.Sprite;
    }

    void SetGroupMinus(FamilyActivity card)
    {
        int cnt = 0;
        for (int i = 0; i < 4; i++)
            if (card.GetAffect(i) < 0)
            {
                GameObject newic;
                if (cnt > 0)
                {
                    newic = Instantiate(oricon);
                    newic.transform.SetParent(groupminus.transform);
                }
                newic = Instantiate(icons[i]);
                newic.transform.SetParent(groupminus.transform);
                ++cnt;
            }
    }
    void SetGroupPlus(FamilyActivity card)
    {
        int cnt = 0;
        for (int i = 0; i < 4; i++)
            if (card.GetAffect(i) > 0)
            {
                GameObject newic;
                if (cnt > 0)
                {
                    newic = Instantiate(oricon);
                    newic.transform.SetParent(groupplus.transform);
                }
                newic = Instantiate(icons[i]);
                newic.transform.SetParent(groupplus.transform);
                ++cnt;
            }
    }
    int GetHealthPlus(FamilyActivity card)
    {
        for (int i = 0; i < 4; i++)
            if (card.GetAffect(i) > 0)
                return card.GetAffect(i);
        return 0;
    }

    int GetHealthMinus(FamilyActivity card)
    {
        for (int i = 0; i < 4; i++)
            if (card.GetAffect(i) < 0)
                return card.GetAffect(i);
        return 0;
    }
}
