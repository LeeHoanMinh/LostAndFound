using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    public static ScoreboardManager Instance;
    private void Awake() {
        Instance = this;
    }
    public void AddResult(int finalDay) {
        int firstRank = PlayerPrefs.GetInt("Top1");
        int secondRank = PlayerPrefs.GetInt("Top2");
        int thirdRank = PlayerPrefs.GetInt("Top3");
        int lastRank = PlayerPrefs.GetInt("Top4");
        if (finalDay <= lastRank)
            return;
        if (finalDay == firstRank || finalDay == secondRank || finalDay == thirdRank)
            return;
        if (finalDay > firstRank) {
            PlayerPrefs.SetInt("Top4", thirdRank);
            PlayerPrefs.SetInt("Top3", secondRank);
            PlayerPrefs.SetInt("Top2", firstRank);
            PlayerPrefs.SetInt("Top1", finalDay);
            return;
        }
        else if (finalDay > secondRank) {
            PlayerPrefs.SetInt("Top4", thirdRank);
            PlayerPrefs.SetInt("Top3", secondRank);
            PlayerPrefs.SetInt("Top2", finalDay);
            return;
        }
        else if (finalDay > thirdRank) {
            PlayerPrefs.SetInt("Top4", thirdRank);
            PlayerPrefs.SetInt("Top3", finalDay);
            return;
        }
        else {
             PlayerPrefs.SetInt("Top4", finalDay);
            return;
        }
    }
    public List<int> GetTopScore() {
        List<int> topScore = new List<int>();
        if (PlayerPrefs.GetInt("Top1") > 0)
            topScore.Add(PlayerPrefs.GetInt("Top1"));
        if (PlayerPrefs.GetInt("Top2") > 0)
            topScore.Add(PlayerPrefs.GetInt("Top2"));
        if (PlayerPrefs.GetInt("Top3") > 0)
            topScore.Add(PlayerPrefs.GetInt("Top3"));
        if (PlayerPrefs.GetInt("Top4") > 0)
            topScore.Add(PlayerPrefs.GetInt("Top4"));
        for (int i = 0; i < topScore.Count; ++i)
            Debug.Log(topScore[i]);
        return topScore;
    }
}
