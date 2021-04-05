using UnityEngine;
using DIL.Library.Utility;
using System.Collections.Generic;

public class FamilyEventManager : MonoBehaviour 
{
    [SerializeField]
    private FamilyEvent[] listFamilyEvent;
    [SerializeField] 
    private FamilyEvent[] listSafeFamilyEvent;
    private EventSpawner spawner;
    private void Awake() 
    {
        spawner = this.GetComponent<EventSpawner>();
    }
    public FamilyEvent GetRandomEvent()
    {
        int order = Random.Range(0, listFamilyEvent.Length);
        bool isValid = IsValidEvent(listFamilyEvent[order]);
        int count = 0;
        while (!isValid)
        {
            if (count == 5) break;
            count++;
            order = Random.Range(0, listFamilyEvent.Length);
            isValid = IsValidEvent(listFamilyEvent[order]);
        }
        if (count == 5)
        {
            bool[] deadStatus = new bool[4];
            int[] indexArr = new int[4];
            int count2 = 0;
            for (int i=0; i<4; i++)
            {
                if (!FamilyMemberManager.Instance.GetFamilyMember((FamilyMemberType)i).IsDead)
                {
                    indexArr[count2] = i;
                    count2++;
                }

            }
            int rnd = Random.Range(0,count2);
            return listSafeFamilyEvent[rnd];
        }
        else
        {
            return listFamilyEvent[order];
        }
    }

    private bool IsValidEvent(FamilyEvent familyEvent)
    {
        for (int i=0; i<4; i++)
        {
            if (FamilyMemberManager.Instance.GetFamilyMember((FamilyMemberType)i) == null) return false;
            if (familyEvent.IsMemberRequired(i) && FamilyMemberManager.Instance.GetFamilyMember((FamilyMemberType)i).IsDead) return false;
        }
        return true;
    }

    public void SpawnEvent()
    {
        FamilyEvent familyEvent = GetRandomEvent();
        spawner.SetLetterContent(familyEvent);
        spawner.EventLetterCome(familyEvent);
    }

}