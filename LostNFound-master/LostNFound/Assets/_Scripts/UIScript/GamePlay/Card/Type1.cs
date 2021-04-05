using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type1 : MonoBehaviour
{
    public Text title;
    public Image img;
    public Text healthplus;
    public Text energy;
    public GameObject[] icons = new GameObject[4];
    public GameObject group;
    public GameObject all;
    public Animator Anim;
    public void SetInfo(FamilyActivity card)
    {
        title.text = card.Title;
        img.sprite = card.Sprite;
        int health = GetHealth(card);
        if (health > 0)
            healthplus.text = '+' + health.ToString();
        else healthplus.text = health.ToString();
        energy.text = card.EnergyCount.ToString();
        int cnt = 0;
        for (int i = 0; i < 4; i++)
            if (card.GetAffect(i) != 0)
                ++cnt;
        if(cnt == 4)
        {
            all.SetActive(true);
            //Set All
            return;
        }

        for (int i = 0;i < 4;i++)
            if(card.GetAffect(i) != 0)
            {
                GameObject newic;

                newic = Instantiate(icons[i]);
                newic.transform.SetParent(group.transform);
            }
        
    }
    private void OnEnable() {
        StartCoroutine(AppearAnim());
    }
    private IEnumerator AppearAnim() {
        Anim.SetTrigger("Appear");
        yield return new WaitForSeconds(.5f);
        Anim.enabled = false;
    }
    int GetHealth(FamilyActivity card)
    {
        for (int i = 0; i < 4; i++)
            if (card.GetAffect(i) != 0)
                return card.GetAffect(i);
        return 0;
    }
}
