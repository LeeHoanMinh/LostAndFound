using UnityEngine.UI;
using DIL.Library.Utility;
using UnityEngine;

public class TextPopEffect : MonoBehaviour
{
    [SerializeField]
    private Color AddColor;
    [SerializeField]
    private Color MinusColor;
    private Text amountText;
    private Animation anim;

    private void Awake() {
        amountText = this.GetComponent<Text>();
        anim = this.GetComponent<Animation>();
    }

    public void StartEffect(int amount)
    {
        if (amount == 0) return;
        if (anim.isPlaying) anim.Stop();
        string text = "";
        Color color = Color.black;
        if (amount > 0)
        {
            text = "+" + amount.ToString();
            color = AddColor;
        }
        else 
        {
            text = amount.ToString();
            color = MinusColor;
        }
        amountText.text = text;
        amountText.color = new Color(color.r, color.g, color.b);
        anim.Play();
    }
}
