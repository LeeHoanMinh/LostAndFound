using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DIL.Library;
using DIL.Library.Features;
using DIL.Library.Utility;

public class BackgroundManager : MonoBehaviour
{
    public BackgroundType CurrentBackgroundType;
    public Animator Anim;
    public Image HappyBG, NormalBG, SadBG;
    public void SwitchState(BackgroundType targetType) {
        CurrentBackgroundType = targetType;
        switch (CurrentBackgroundType) {
            case BackgroundType.Happy:
                StartFadeIn(HappyBG);
                StartFadeOut(NormalBG);
                StartFadeOut(SadBG);
                break;
            case BackgroundType.Normal:
                StartFadeOut(HappyBG);
                StartFadeIn(NormalBG);
                StartFadeOut(SadBG);
                break;
            case BackgroundType.Sad:
                StartFadeOut(HappyBG);
                StartFadeOut(NormalBG);
                StartFadeIn(SadBG);
                break;
        }
    }    
    public void StartFadeIn(Image IMG)
    {
        StartCoroutine(FadeIn(IMG));
    }
    IEnumerator FadeIn(Image IMG)
    {
        IMG.enabled = true;
        for (float f = 0; f < 1; f += 0.05f)
        {
            Color c = IMG.color;
            c.a = f;
            IMG.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void StartFadeOut(Image IMG)
    {
        StartCoroutine(FadeOut(IMG));
    }
    IEnumerator FadeOut(Image IMG)
    {
        if (!IMG.enabled)
            yield return null;
        for (float f = 1; f > 0; f -= 0.05f)
        {
            Color c = IMG.color;
            c.a = f;
            IMG.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        IMG.enabled = false;
    }
}
