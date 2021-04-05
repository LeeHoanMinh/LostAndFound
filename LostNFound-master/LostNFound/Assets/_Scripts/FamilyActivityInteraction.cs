using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FamilyActivityInteraction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform Parent;
    public bool CanPlay = true;
    public float scaleInDragging;
    public FamilyActivity familyActivity;
    public int originalID;
    private Transform parentToReturnTo = null;
    private void Update() {
        //hot fix bug 2 fingers
        if (Input.touchCount > 1)
            CanPlay = false;
        else
            CanPlay = true;
    }
    public void OnBeginDrag(PointerEventData eventData) {
        if (CanPlay && Time.timeScale == 1) {
            originalID = this.transform.GetSiblingIndex();
            this.transform.localScale = new Vector3(scaleInDragging, scaleInDragging, 0);
            parentToReturnTo = this.transform.parent;
            Player.Instance.IsSuccessPlay = false;
            FamilyActivitySpawner.Instance.CurrentFamilyActivityID = this.gameObject.transform.GetSiblingIndex();
        }
        else {
            for (int i = 0; i < this.transform.parent.childCount; ++i) {
                this.transform.localScale = new Vector3(.3f, .3f, 0);
                int id = this.transform.parent.GetChild(i).GetComponent<FamilyActivityInteraction>().originalID;
                this.transform.parent.GetChild(i).position = FamilyActivitySpawner.Instance.constposition[i].position;
            }
        }
    }
    public void OnDrag(PointerEventData eventData) {
        if (CanPlay && Time.timeScale == 1)
            this.transform.position = eventData.position;
        else {
            for (int i = 0; i < this.transform.parent.childCount; ++i) {
                this.transform.localScale = new Vector3(.3f, .3f, 0);
                int id = this.transform.parent.GetChild(i).GetComponent<FamilyActivityInteraction>().originalID;
                this.transform.parent.GetChild(i).position = FamilyActivitySpawner.Instance.constposition[i].position;
            }
        }
    } 
    public void OnEndDrag(PointerEventData eventData) {
        if (CanPlay && Time.timeScale == 1) {
            this.transform.localScale = new Vector3(.3f, .3f, 0);
            //if Player play card failed -> return it to deck
            if (!Player.Instance.IsSuccessPlay) {
                this.transform.position = FamilyActivitySpawner.Instance.constposition[originalID].position;
                AudioManager.AM.Play("DropCard");
            }
            else {
                this.gameObject.transform.SetParent(null);
                FamilyActivityManager.Instance.PickActivity(FamilyActivitySpawner.Instance.CurrentFamilyActivityID);
                FamilyActivitySpawner.Instance.SpawnActivity(originalID, FamilyActivityManager.Instance.GetActivityRowAt(originalID));
                GameObject.Destroy(this.gameObject);
            }
            FamilyActivitySpawner.Instance.CurrentFamilyActivityID = -1;
        }
    }
}
