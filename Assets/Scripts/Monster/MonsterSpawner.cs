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
        if (GameObject.FindGameObjectWithTag("Animal") != null) Destroy(GameObject.FindGameObjectWithTag("Animal"));
        Element e = Utilities.GetRandomElement();
        switch (e)
        {
            case Element.Air:
                AirMonsterPrefab.GetComponent<Monster>().newMonster(Element.Air);
                Instantiate(AirMonsterPrefab, spawnerTransform);
                break;
            case Element.Earth:
                EarthMonsterPrefab.GetComponent<Monster>().newMonster(Element.Earth);
                Instantiate(EarthMonsterPrefab, spawnerTransform);
                break;
            case Element.Water:
                WaterMonsterPrefab.GetComponent<Monster>().newMonster(Element.Water);
                Instantiate(WaterMonsterPrefab, spawnerTransform);
                break;
            case Element.Fire:
                FireMonsterPrefab.GetComponent<Monster>().newMonster(Element.Fire);
                Instantiate(FireMonsterPrefab, spawnerTransform);
                break;
            default:
                //monsterPrefab.GetComponent<Monster>().newMonster();
                //Instantiate(monsterPrefab, spawnerTransform);
                break;
        }
    }
}
