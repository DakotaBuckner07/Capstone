using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform spawnerTransform;

    public void newMonster()
    {
        monsterPrefab.GetComponent<Monster>().newMonster();
        Instantiate(monsterPrefab, spawnerTransform);
    }
}
