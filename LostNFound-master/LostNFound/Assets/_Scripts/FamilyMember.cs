using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DIL.Library;
using DIL.Library.Utility;

public class FamilyMember : MonoBehaviour
{
    //Safe zone
    public int decreasedValue;
    public float speedMove;
    public SpriteRenderer Emotion;
    public Sprite[] EmotionType;
    public FamilyMemberType Type;
    public Animator Anim;
    public int HappyValue, Cooldown;
    public bool CanBeAffect, CanMove, IsMoving, IsDead;
    public FamilyMemberHappyType HappyType;
    public Image HappyValueFill;
    public Image HappyValueIMG;
    public TextPopEffect textPopEffect;
    public Image CountdownFill;
    public GameObject HeartImg;
    public WrongTextFx wrongText;
    public Color[] HappyColors;
  
    private void Start() {
        // CalculateBorder();
        TimeManager.Instance.OnOneTimeStep += DecreaseHappyValue;
    }
    private void Update() {
        UpdateHappyValueUI();
    }
    public void DecreaseHappyValue() {
        ActivateEffect(-decreasedValue, AffectType.time);
    }
    public void UpdateHappyValueUI() {
        if (HappyValue > 100)
            HappyValue = 100;
        HappyValueFill.fillAmount = (float)HappyValue / (float)100;
        HappyValueIMG.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, 1, 0));
        ChangeHappyType();
    }
    public void ActivateEffect(int amount, AffectType type)
    {
        if (type == AffectType.time) {
            HappyValue += amount;
        }
        else if (type == AffectType.card)
        {
            if (!CanBeAffect)
            {
                return;
            }
            if (amount == 0) return;
            HappyValue += amount;
            if (CanBeAffect)
                StartCoroutine(StartCooldown());
            if (amount > 0)
            {
                AudioManager.AM.Play("Bonus");
            }
            else if (amount < 0)
            {
                AudioManager.AM.Play("Negative");
            }
        }
        else if (type == AffectType.letter)
        {
            HappyValue += amount;
        }
        textPopEffect.StartEffect(amount);
    }
    public void ChangeHappyType() {
        if (!IsDead)
        {
            if (HappyValue >= 80)
            {
                HappyValueFill.color = HappyColors[0];
                HappyType = FamilyMemberHappyType.Happy;
                Emotion.sprite = EmotionType[5];
            }
            else if (HappyValue >= 60)
            {
                HappyValueFill.color = HappyColors[0];
                HappyType = FamilyMemberHappyType.Good;
                Emotion.sprite = EmotionType[4];
            }
            else if (HappyValue >= 40)
            {
                HappyValueFill.color = HappyColors[0];
                HappyType = FamilyMemberHappyType.Normal;
                Emotion.sprite = EmotionType[3];
            }
            else if (HappyValue >= 20)
            {
                HappyValueFill.color = HappyColors[1];
                HappyType = FamilyMemberHappyType.Sad;
                Emotion.sprite = EmotionType[2];
            }
            else if (HappyValue >= 1)
            {
                HappyValueFill.color = HappyColors[2];
                HappyType = FamilyMemberHappyType.Angry;
                Emotion.sprite = EmotionType[1];
            }
            else
            {
                HappyType = FamilyMemberHappyType.Gone;
                GoDead();
                GameManager.Instance.DeadCount++;
                if (GameManager.Instance.DeadCount == 4)
                {
                    Debug.Log("LOSE");
                    GameEventHandler.Instance.LoseGame();
                }
            }
        }
    }
    private void GoDead()
    {
        IsDead = true;
        Anim.enabled = false;
        StartFadeOut(this.GetComponent<SpriteRenderer>());
        StartFadeOut(this.Emotion);
        HappyValueIMG.gameObject.SetActive(false);
        HeartImg.SetActive(false);
        textPopEffect.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    private IEnumerator StartCooldown() {
        CanBeAffect = false;
        Cooldown = 10;
        int cnt = 0;
        HeartImg.SetActive(false);
        CountdownFill.fillAmount = 1;
        while (Cooldown > 0) {
            cnt++;
            CountdownFill.fillAmount -= 0.002f;
            if(cnt == 50)
            {
                Cooldown--;
                cnt = 0;
            }
            yield return new WaitForSeconds(0.02f);
        } 
        CanBeAffect = true;
        HeartImg.SetActive(true);
        yield return null;
    }
    public void StartMove(Vector3 targetPosition) {
        StartCoroutine(Move(targetPosition));
    }
    private IEnumerator Move(Vector3 targetPosition) {
        IsMoving = true;
        while (Mathf.Abs(this.transform.position.x - targetPosition.x) > 0.01f || Mathf.Abs(this.transform.position.y - targetPosition.y) > 0.01f) {
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speedMove * Time.deltaTime);
            yield return new WaitForSeconds(0.02f);
        }
        IsMoving = false;
        yield return null;
    }
    public void StartFadeOut(SpriteRenderer rend)
    {
        StartCoroutine(FadeOut(rend));
    }
    IEnumerator FadeOut(SpriteRenderer rend)
    {
        if (!rend.enabled)
            yield return null;
        for (float f = 1; f > 0; f -= 0.025f)
        {
            Color c = rend.color;
            c.a = f;
            rend.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        rend.enabled = false;
    }
}
