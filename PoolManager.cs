using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public GameObject[] prepabs;
    List<GameObject>[] pools;

    void Awake() {

        List<GameObject>[] pools = new List<GameObject>[prepabs.Length];
        for(int i = 0; i < prepabs.Length; i++) {
            pools[i] = new List<GameObject>();
        }
    }


    public GameObject Get(int prepabId) {
        GameObject select = null;

        foreach(GameObject item in pools[prepabId]) {
            if (!item.activeSelf) {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select) {

            select = Instantiate(prepabs[prepabId], transform);
            pools[prepabId].Add(select);
        }

        return select;
    }
}
