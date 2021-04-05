using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIL.Library.Utility;

public class FamilyActivity : MonoBehaviour
{
    [SerializeField]
    private string title;
    [SerializeField]
    private string description;
    [SerializeField]
    private int energyCount = 0;

    [SerializeField]
    private ActivityInteract interact;

    [SerializeField]
    private ActivityType type;

    [SerializeField]
    private ActivityStar star;
    
    [SerializeField]
    private int[] affects;
    [SerializeField]
    private Sprite sprite;
    public string Title { get {return title;}}
    public string Description { get {return description;}}
    public int EnergyCount { get { return energyCount;}}
    public ActivityInteract Interact { get { return interact;}}
    public ActivityType Type { get { return type;}} 
    public ActivityStar Star { get { return star;}}
    public Sprite Sprite { get { return sprite;}}
    public int ID;
    public int GetAffect(int id)
    {
        return affects[id];
    }
    public int GetAffectLength() 
    {
        return affects.Length;
    }

    public void Activate()
    {
        if (Interact == ActivityInteract.nontarget)
        {
            for (int i = 0; i < 4; i++)
            {
                var member = FamilyMemberManager.Instance.GetFamilyMember((FamilyMemberType)i);
                member.ActivateEffect(affects[i], AffectType.card);
            }
        }
        else
        for (int i=0; i<4; i++)
        {
            var member = FamilyMemberManager.Instance.GetFamilyMember((FamilyMemberType)i);
            if (member.gameObject.name == Player.Instance.GetCurrentTarget().name) 
                member.ActivateEffect(affects[i], AffectType.card);
        }
        Player.Instance.SetEnergy(energyCount);
    }
    public bool CheckMemberAffect(FamilyMemberType member)
    {
        if (affects[(int)member] != 0 && Player.Instance.EnergyValue - energyCount >= 0)
            return true;
        return false;
    }
    public void Copy(FamilyActivity other) {
        this.title = other.Title;
        this.description = other.Description;
        this.star = other.Star;
        this.energyCount = other.EnergyCount;
        this.interact = other.Interact;
        this.type = other.Type;
        this.sprite = other.Sprite;
        this.ID = other.ID;
        affects = new int[other.GetAffectLength()];
        for (int i = 0; i < this.affects.Length; ++i)
            this.affects[i] = other.GetAffect(i);    
    }

}
