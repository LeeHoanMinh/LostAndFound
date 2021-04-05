using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIL.Library;
using DIL.Library.Features;
public class Player : MonoBehaviour
{   
    public static Player Instance;
    public bool IsSuccessPlay;
    public int EnergyValue, EnergyCost, EnergyAdd;
    public EnergyUI EnergyUI;
    private void Awake() {
        Instance = this;
    }
    public GameObject GetCurrentTarget() {
        return InputHandler.Instance.GetHoveredObject();
    }
    public void AddEnergy() {
        EnergyValue += EnergyAdd;
        EnergyUI.SetEnergy(EnergyValue);
    }
    public void SetEnergy(int energyCost) {
        EnergyValue -= energyCost;
        if (EnergyValue < 0)
            EnergyValue = 0;
        EnergyUI.SetEnergy(EnergyValue);
    }
}
