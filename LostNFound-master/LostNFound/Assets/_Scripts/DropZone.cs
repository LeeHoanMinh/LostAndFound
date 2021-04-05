using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool CanPlay = true;
    private void Update() {
        if (Input.touchCount > 1)
            CanPlay = false;
        else    
            CanPlay = true;
    }
    public void OnPointerEnter(PointerEventData eventData) {
    }
    public void OnPointerExit(PointerEventData eventData) {
    }
    public void OnDrop(PointerEventData eventData) {
        if (CanPlay) {
            if (FamilyActivityManager.Instance.GetActivityRowAt(FamilyActivitySpawner.Instance.CurrentFamilyActivityID).Interact == DIL.Library.Utility.ActivityInteract.target) {
                if (Player.Instance.GetCurrentTarget()) {
                    //Drop on family member
                
                    var activity = FamilyActivityManager.Instance.GetActivityRowAt(FamilyActivitySpawner.Instance.CurrentFamilyActivityID);
                    var member = Player.Instance.GetCurrentTarget().GetComponent<FamilyMember>();
                    if (!Player.Instance.GetCurrentTarget().GetComponent<FamilyMember>().CanBeAffect)
                    {
                        //pop up...
                        member.wrongText.RunEffect();
                        Player.Instance.IsSuccessPlay = false;
                        return;
                    }
                    if (!activity.CheckMemberAffect(member.Type))
                    {
                        Player.Instance.IsSuccessPlay = false;
                        return;
                    }
                    Debug.Log("OnDropTo:" + Player.Instance.GetCurrentTarget().name);
                    Player.Instance.IsSuccessPlay = true;
                    return;
                }
                else {
                    Player.Instance.IsSuccessPlay = false;
                    return;
                }
            }
            else 
            //Drop all
            Player.Instance.IsSuccessPlay = true;
        }
        else 
            Player.Instance.IsSuccessPlay = false;
    }
}
