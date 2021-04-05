using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIL.Library.Utility;

public class FamilyMemberManager : MonoBehaviour
{
    public static FamilyMemberManager Instance;
    public int TimeDelay;
    public int[] PositionInID;
    public Transform[] TargetPosition;
    public bool[] IsAvailable;
    public bool CanMove;
    private void Awake() {
        Instance = this;
        for (int i = 0; i < this.transform.childCount; ++i)
            this.transform.GetChild(i).transform.position = TargetPosition[PositionInID[i]].position;
        StartCoroutine(CallMove());
    }
    public FamilyMember GetFamilyMember(FamilyMemberType typeValue) {
        return this.transform.GetChild((int)typeValue).GetComponent<FamilyMember>();
    }
    private IEnumerator CallMove() {
        while (CanMove) {
            DecideMove();
            yield return new WaitForSeconds(TimeDelay);
        }
        yield return null;
    }
    public void DecideMove() {
        int num1 = Random.Range(0, 3);
        int num2 = Random.Range(0, 3);
        if (num1 == num2) 
        {
            Move(num1);
        }
        else
        {
            Move(num1);
            Move(num2);
        }
    }
    private void Move(int num) {
        int id = Random.Range(0, TargetPosition.Length);
        IsAvailable[PositionInID[num]] = true;
        while (!IsAvailable[id])
            id = Random.Range(0, TargetPosition.Length);
        var target =  this.transform.GetChild(num).GetComponent<FamilyMember>();
        target.StartMove(TargetPosition[id].position);
        PositionInID[num] = id;
        IsAvailable[id] = false;
    }
}
