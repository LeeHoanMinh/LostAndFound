using UnityEngine.UI;
using UnityEngine;

public class WrongTextFx : MonoBehaviour
{
    [SerializeField]
    private string[] poolTalk;
    [SerializeField]
    private Color color;
    private Animation anim;
    private Text text;
    private void Awake() 
    {
        if (anim == null) anim = this.GetComponent<Animation>();
        if (text == null) text = this.GetComponent<Text>();
    }

    public void RunEffect()
    {
        if (anim.isPlaying) anim.Stop();
        text.text = poolTalk[Random.Range(0,poolTalk.Length)].ToString();
        text.color = new Color(color.r, color.g, color.b);
        anim.Play();
    }
}
