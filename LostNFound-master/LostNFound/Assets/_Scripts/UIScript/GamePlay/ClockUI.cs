using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    public GameObject Arrow;
    public Color morningColor;
    public Color noonColor;
    public Color nigthColor;
    private Image arrowImg;
    private void Awake() {
        arrowImg = Arrow.GetComponent<Image>();
    }
    public void SetArrow(float percent)
    {
        if (percent > 0 && percent < 0.6f)
        {
            arrowImg.color = morningColor;
        }
        else if (percent > 0.6f && percent < 0.8f)
        {
            arrowImg.color = noonColor;
        }
        else
        {
            arrowImg.color = nigthColor;
        }
        Arrow.transform.rotation = new Quaternion(0, 0, 0, 0);
        Arrow.transform.Rotate(0, 0, -percent * 360, 0);
    }

}
