using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject shopScreen;
    [SerializeField]
    private GameObject itemPrefab;

    private List<Shield> shields = new List<Shield>();
    private List<Weapon> weapons = new List<Weapon>();
    private List<Potion> potions = new List<Potion>();

    private void newShop()
    {
        shields.Clear();
        weapons.Clear();
        potions.Clear();
        for(int i = 0; i < 3; i++)
        {
            int value = Utilities.GetRandNumTimesLevel(1, 5);
            shields.Add(new Shield(value, Utilities.GetRandomElement(), (int)(value * Random.Range(1.0f, 2.0f))));
            weapons.Add(new Weapon(value, Utilities.GetRandomElement(), (int)(value * Random.Range(1.0f, 2.0f))));
        }
        for(int i = 0; i < 5; i++)
        {
            int potionType = Random.Range(0, 3);
            {
                switch (potionType)
                {
                    case 0:
                        int value = Utilities.GetRandNumTimesLevel(2, 5);
                        Debug.Log("Resistance");
                        potions.Add(new ResistancePotion(Utilities.GetRandomElement(), value, Random.Range(1, 3), (int)(value * Random.Range(1.0f, 2.0f))));
                        break;
                    case 1:
                        value = Utilities.GetRandNumTimesLevel(3, 10);
                        Debug.Log("Damage");
                        potions.Add(new DamagePotion(Utilities.GetRandomElement(), value, (int)(value * Random.Range(1.0f, 2.0f))));
                        break;
                    case 2:
                        value = Utilities.GetRandNumTimesLevel(10, 15);
                        Debug.Log("Health");
                        potions.Add(new HealthPotion(value, (int)(value * Random.Range(1.3f, 2.0f))));
                        break;
                }
            }
        }
    }

    public void OpenShop()
    {
        newShop();
        if (shopScreen.activeInHierarchy)
        {
            shopScreen.SetActive(false);
            foreach (Transform child in shopScreen.transform)
            {
                foreach (Transform secondChild in child.transform)
                {
                    Destroy(secondChild.gameObject);
                }
            }
        }
        else
        {
            Item itemPrefabItem = itemPrefab.GetComponent<Item>();
            shopScreen.SetActive(true);
            //itemPrefab.GetComponent<Image>().sprite = itemPrefabItem.armorSprite;

            foreach (Shield a in shields)
            {
                itemPrefabItem.priceTxt.text = a.Price.ToString();
                itemPrefabItem.pointTxt.text = a.Resistance.ToString();

                GameObject armor = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                armor.transform.SetParent(GameObject.FindGameObjectWithTag("ShopArmor").transform, false);
            }
            //itemPrefab.GetComponent<Image>().sprite = itemPrefabItem.weaponSprite;

            foreach (Weapon w in weapons)
            {
                itemPrefabItem.priceTxt.text = w.Price.ToString();
                itemPrefabItem.pointTxt.text = w.Damage.ToString();

                GameObject weapon = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                weapon.transform.SetParent(GameObject.FindGameObjectWithTag("ShopWeapons").transform, false);
            }
            //itemPrefab.GetComponent<Image>().sprite = itemPrefabItem.potionSprite;

            foreach (Potion p in potions)
            {
                itemPrefabItem.priceTxt.text = p.Price.ToString();
                itemPrefabItem.pointTxt.text = p.Value.ToString();

                GameObject potion = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                potion.transform.SetParent(GameObject.FindGameObjectWithTag("ShopPotions").transform, false);
            }
        }
    }
}
