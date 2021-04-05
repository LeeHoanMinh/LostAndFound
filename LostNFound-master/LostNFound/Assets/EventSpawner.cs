using System.Collections;
using System.Collections.Generic;
using DIL.Library;
using UnityEngine.UI;
using UnityEngine;

public class EventSpawner : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text desText;
    [SerializeField]
    private Animator anim;
    private float animTime;
    private bool readed = false;
    private FamilyEvent currentFamilyEvent;

    public void SetLetterContent(FamilyEvent familyEvent)
    {
        titleText.text = familyEvent.Title.ToString();
        desText.text = familyEvent.Description.ToString();
    }

    public void EventLetterCome(FamilyEvent fEvent)
    {
        currentFamilyEvent = fEvent;
        TimeManager.Instance.HoldGame();
        anim.SetTrigger("ShowAnim");
        readed = false;
    }

    public void SkipAnim()
    {
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hide")) anim.SetTrigger("HideAnim");
        //else anim.SetTrigger("SkipAnim");
    }

    public void HideLetter()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Showed")) return;
        if(readed) return;
        readed = true;
        TimeManager.Instance.DeHoldGame();
        currentFamilyEvent.Activate();
        anim.SetTrigger("HideAnim");
    }


}
