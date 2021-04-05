using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyActivitySpawner : MonoBehaviour
{
    public static FamilyActivitySpawner Instance;
    public int CurrentFamilyActivityID;
    public Transform[] constposition;
    private void Awake() {
        Instance = this;
    }
    public int IndexToSpawn;
    public GameObject[] ActivityPrefab;
    public void DeleteActivity() {
        for (int i = 0; i < this.transform.childCount; ++i)
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
    }
    public void SpawnActivity(int id, FamilyActivity familyActivity) {
        GameObject GO;
        GO = Instantiate(ActivityPrefab[(int)familyActivity.Type], Vector3.zero, Quaternion.identity);
        GO.transform.SetParent(this.transform);
        GO.transform.SetSiblingIndex(id);
        GO.transform.position = constposition[id].position;
        GO.GetComponent<FamilyActivityInteraction>().familyActivity.Copy(familyActivity);
        GO.GetComponent<Type1>().SetInfo(GO.GetComponent<FamilyActivity>());
    }
}
