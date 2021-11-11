using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject WaterMonsterPrefab;
    public GameObject EarthMonsterPrefab;
    public GameObject FireMonsterPrefab;
    public GameObject AirMonsterPrefab;
    public Transform spawnerTransform;

    public void newMonster()
    {
        Element e = Utilities.GetRandomElement();
        Debug.Log(e.ToString());
        switch (e)
        {
            case Element.Air:
                Instantiate(AirMonsterPrefab, spawnerTransform);
                break;
            case Element.Earth:
                Instantiate(EarthMonsterPrefab, spawnerTransform);
                break;
            case Element.Water:
                Instantiate(WaterMonsterPrefab, spawnerTransform);
                break;
            case Element.Fire:
                Instantiate(FireMonsterPrefab, spawnerTransform);
                break;
            default:
                //monsterPrefab.GetComponent<Monster>().newMonster();
                //Instantiate(monsterPrefab, spawnerTransform);
                break;
        }
    }
}
