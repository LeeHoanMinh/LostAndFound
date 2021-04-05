using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIL.Library;
using DIL.Library.Features;
using DIL.Library.Utility;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad Instance;
    private void Awake() {
        Instance = this;
        
    }
    public void Save() {
        PlayerPrefs.SetInt("Day", TimeManager.Instance.CurDay);
        PlayerPrefs.SetInt("Time", TimeManager.Instance.CurTime);
        PlayerPrefs.SetInt("Energy", Player.Instance.EnergyValue);
        PlayerPrefs.SetInt("CD1", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Dad).Cooldown);
        PlayerPrefs.SetInt("CD2", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Mom).Cooldown);
        PlayerPrefs.SetInt("CD3", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Bro).Cooldown);
        PlayerPrefs.SetInt("CD4", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Sis).Cooldown);
        PlayerPrefs.SetInt("HV1", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Dad).HappyValue);
        PlayerPrefs.SetInt("HV2", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Mom).HappyValue);
        PlayerPrefs.SetInt("HV3", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Bro).HappyValue);
        PlayerPrefs.SetInt("HV4", FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Sis).HappyValue);
        PlayerPrefs.SetInt("ID1", FamilyActivityManager.Instance.GetActivityRowAt(0).ID);
        PlayerPrefs.SetInt("ID2", FamilyActivityManager.Instance.GetActivityRowAt(1).ID);
        PlayerPrefs.SetInt("ID3", FamilyActivityManager.Instance.GetActivityRowAt(2).ID);
    }
    public void Load() {
        TimeManager.Instance.CurDay = PlayerPrefs.GetInt("Day");
        TimeManager.Instance.CurTime = PlayerPrefs.GetInt("Time");
        Player.Instance.EnergyValue = PlayerPrefs.GetInt("Energy");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Dad).Cooldown = PlayerPrefs.GetInt("CD1");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Mom).Cooldown = PlayerPrefs.GetInt("CD2");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Bro).Cooldown = PlayerPrefs.GetInt("CD3");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Sis).Cooldown = PlayerPrefs.GetInt("CD4");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Dad).HappyValue = PlayerPrefs.GetInt("HV1");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Mom).HappyValue = PlayerPrefs.GetInt("HV2");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Bro).HappyValue = PlayerPrefs.GetInt("HV3");
        FamilyMemberManager.Instance.GetFamilyMember(FamilyMemberType.Sis).HappyValue = PlayerPrefs.GetInt("HV4");
    }
}
