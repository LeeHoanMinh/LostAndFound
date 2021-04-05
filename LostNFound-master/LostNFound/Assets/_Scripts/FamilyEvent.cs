using System.Collections;
using System.Collections.Generic;
using DIL.Library.Utility;
using UnityEngine;

//sorry for my bad code in case you are reading this =))
//DevInLove team

public class FamilyEvent : MonoBehaviour
{
    [SerializeField]
    private string title = default;

    [SerializeField]
    private string description = default;

    [SerializeField]
    private int[] affects;
    [SerializeField]
    private bool[] requireChar = new bool[4];

    public string Title { get { return title; } }
    public string Description { get { return description; } }
    public int GetAffect(int id)
    {
        return affects[id];
    }
    public bool IsMemberRequired(int i)
    {
        return requireChar[i];
    }
    public void Activate()
    {
        for (int i=0; i<4; i++)
        {
            var member = FamilyMemberManager.Instance.GetFamilyMember((FamilyMemberType)i);;
            member.ActivateEffect(affects[i], AffectType.letter);
        }
    }
}
