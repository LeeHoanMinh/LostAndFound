using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public Text EnergyText;
    public void SetEnergy(int energyValue) {
        EnergyText.text = energyValue.ToString();
    }
}
