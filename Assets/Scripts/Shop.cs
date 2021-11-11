using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject swordPrefab;
    [SerializeField]
    private GameObject shieldPrefab;
    [SerializeField]
    private GameObject dmgPotPrefab;
    [SerializeField]
    private GameObject resPotPrefab;
    [SerializeField]
    private GameObject hpPotPrefab;

    private void Start()
    {
        newShop();
    }

    public void newShop()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();
        for (int i = 1; i <= transforms.Length - 4; i++)
        {
            if (transforms[i].childCount > 0)
            {
                Destroy(transforms[i].GetChild(0).gameObject, 0);
            }
        }
        for (int i = 1; i <= transforms.Length - 4; i++)
        {
            int type = Random.Range(0, 5);
            switch (type)
            {
                case 0:
                    swordPrefab.GetComponent<Weapon>().changeWeapon();
                    Instantiate(swordPrefab, transforms[i]);
                    break;
                case 1:
                    shieldPrefab.GetComponent<Shield>().changeShield();
                    Instantiate(shieldPrefab, transforms[i]);
                    break;
                case 2:
                    resPotPrefab.GetComponent<ResistancePotion>().changePotion();
                    Instantiate(resPotPrefab, transforms[i]);
                    break;
                case 3:
                    dmgPotPrefab.GetComponent<DamagePotion>().changePotion();
                    Instantiate(dmgPotPrefab, transforms[i]);
                    break;
                case 4:
                    hpPotPrefab.GetComponent<HealthPotion>().changePotion();
                    Instantiate(hpPotPrefab, transforms[i]);
                    break;
                default:
                    break;
            }
        }
    }
}
