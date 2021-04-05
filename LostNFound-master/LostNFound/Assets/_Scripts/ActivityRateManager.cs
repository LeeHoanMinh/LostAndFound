using UnityEngine;
using DIL.Library.Utility;

public class ActivityRateManager : MonoBehaviour 
{
    [SerializeField]
    private int[] starOneRate;

    [SerializeField]
    private int[] starTwoRate;

    [SerializeField]
    private int[] starThreeRate;

    [SerializeField]
    private int[] starFourRate;

    public int GetRate(ActivityStar star, int day)
    {
        int[] starRate;
        switch(star)
        {
            case (ActivityStar.one) :
            {
                starRate = starOneRate;
                break;
            }
            case (ActivityStar.two) :
            {
                starRate = starTwoRate;
                break;
            }
            case (ActivityStar.three) :
            {
                starRate = starThreeRate;
                break;
            }
            case (ActivityStar.four) :
            {
                starRate = starFourRate;
                break;
            }
            default: 
            {
                starRate = starOneRate;
                break;
            }
        }

        if (day >= starRate.Length) 
        {
            return starRate[starRate.Length-1];
        }
        else return starRate[day];
    }
}