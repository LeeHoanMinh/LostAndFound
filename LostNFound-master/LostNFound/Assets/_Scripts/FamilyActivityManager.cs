
using DIL.Library.Utility;
using System.Collections.Generic;
using UnityEngine;
using DIL.Library;

public class FamilyActivityManager : MonoBehaviour
{
    public PopUpEnergyFx PopUpEnergyFx;
    public static FamilyActivityManager Instance;
    [SerializeField]
    private FamilyActivity[] listOneStarActivity;

    [SerializeField]
    private FamilyActivity[] listTwoStarActivity;

    [SerializeField]
    private FamilyActivity[] listThreeStarActivity;

    [SerializeField]
    private FamilyActivity[] listFourStarActivity;

    [SerializeField]
    private int poolAmount = 100;
    public ActivityRateManager rateManager;
//-----------------------------------------------------------------------------------
    private Queue<FamilyActivity> currentActivityPool;
    private FamilyActivity[] currentActivityRow;
//-----------------------------------------------------------------------------------
    private void Awake() 
    {
        Instance = this;
        GameEventHandler.Instance.OnInitGame += OnInitGame;
    }
    private void OnInitGame() {
        currentActivityPool = new Queue<FamilyActivity>();
        currentActivityRow = new FamilyActivity[3];
        CreatePool();
        Roll();
    }
    public void OnLoadGame() {
        // SaveLoad.Instance.Load();
        // currentActivityPool = new Queue<FamilyActivity>();
        // currentActivityRow = new FamilyActivity[3];
        // currentActivityPool.Enqueue(GetActivityFromID(PlayerPrefs.GetInt("ID1")));
        // currentActivityPool.Enqueue(GetActivityFromID(PlayerPrefs.GetInt("ID2")));
        // currentActivityPool.Enqueue(GetActivityFromID(PlayerPrefs.GetInt("ID3")));
        // CreatePool();
        // Roll();
    }

    public FamilyActivity GetActivityFromID(int id)
    {
        int star = (int)(id/1000);
        if (id == 1)
        {
            foreach (var act in listOneStarActivity)
            {
                if (act.ID == id) return act;
            }
        }
        else if (id == 2)
        {
            foreach (var act in listTwoStarActivity)
            {
                if (act.ID == id) return act;
            }
        }
        else if (id == 3)
        {
            foreach (var act in listThreeStarActivity)
            {
                if (act.ID == id) return act;
            }
        }
        else if (id == 4)
        {
            foreach (var act in listFourStarActivity)
            {
                if (act.ID == id) return act;
            }
        }
        return null;
    }
    public FamilyActivity GetActivityRowAt(int id)
    { 
        return currentActivityRow[id];
    }

    public void Roll()
    {
        if (Player.Instance.EnergyValue < Player.Instance.EnergyCost)
            return;
        FamilyActivitySpawner.Instance.DeleteActivity();
        FamilyActivity act;
        for(int i = 0; i < 3; i++)
        {
            if (currentActivityPool.Count < 4 ) CreatePool();
            act = currentActivityPool.Dequeue();
            currentActivityRow[i] = act;
            FamilyActivitySpawner.Instance.SpawnActivity(i, currentActivityRow[i]);
        }
        Player.Instance.SetEnergy(2);
        PopUpEnergyFx.PlayEffect(-2);
    }

    public void PickActivity(int id)
    {
        if (id > 3) 
        {
            Debug.LogError("Wrong activity ID");
            return;
        }
        currentActivityRow[id].Activate();
        if (currentActivityPool.Count < 4) CreatePool();
        currentActivityRow[id] = currentActivityPool.Dequeue();
    }


    public void CreatePool()
    {
        currentActivityPool.Clear();
        int day = TimeManager.Instance.CurDay;
        //int day = 0;
        int rateOne = rateManager.GetRate(ActivityStar.one,day);
        int rateTwo = rateManager.GetRate(ActivityStar.two,day);
        int rateThree = rateManager.GetRate(ActivityStar.three,day);
        int rateFour = rateManager.GetRate(ActivityStar.four,day);  
        int total = rateOne + rateTwo + rateThree + rateThree;
        int scale = (int)(poolAmount / total);
        FamilyActivity[] tempList = new FamilyActivity[poolAmount];
        int count = 0;
        int order = 0;
        for (int i=0; i<rateOne*scale; i++, count++)
        {
            order = UnityEngine.Random.Range(0, listOneStarActivity.Length);
            tempList[count] = listOneStarActivity[order];
        }

        for (int i=0; i<rateTwo*scale; i++, count++)
        {
            order = UnityEngine.Random.Range(0, listTwoStarActivity.Length);
            tempList[count] = listTwoStarActivity[order];
        }

        for (int i=0; i<rateThree*scale; i++, count++)
        {
            order = UnityEngine.Random.Range(0, listThreeStarActivity.Length);
            tempList[count] = listThreeStarActivity[order];
        }

        for (int i=0; i<rateFour*scale; i++, count++)
        {
            order = UnityEngine.Random.Range(0, listFourStarActivity.Length);
            tempList[count] = listFourStarActivity[order];
        }
        //shuffle
        int n = tempList.Length;
        FamilyActivity temp;
        for (int i=0; i<n; i++)
        {
            order = UnityEngine.Random.Range(i, n);
            temp = tempList[order];
            tempList[order] = tempList[i];
            tempList[i] = temp;
            currentActivityPool.Enqueue(tempList[i]);
        }
    }
}
