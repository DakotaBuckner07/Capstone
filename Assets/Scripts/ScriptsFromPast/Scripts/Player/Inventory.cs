using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryScreen;
    public GameObject itemPrefab;

    private List<Armor> armors = new List<Armor>();
    private List<Weapon> weapons = new List<Weapon>();
    private List<Potion> potions = new List<Potion>();

    #region AddAndRemoveWeapons
    public void RemoveWeapon(Weapon w)
    {
        weapons.Remove(w);
    }
    public void RemoveArmor(Armor a)
    {
        armors.Remove(a);

    }
    public void RemovePotion(Potion p)
    {
        potions.Remove(p);
    }
    public void AddWeapon(Weapon w)
    {
        weapons.Add(w);
    }
    public void AddArmor(Armor a)
    {
        armors.Add(a);

    }
    public void AddPotion(Potion p)
    {
        potions.Add(p);
    }
    #endregion

    public void OpenInventory()
    {
        if(inventoryScreen.activeInHierarchy)
        {
            inventoryScreen.SetActive(false);
            foreach (Transform child in inventoryScreen.transform)
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            inventoryScreen.SetActive(true);
            Button[] inventoryBtns = inventoryScreen.GetComponentsInChildren<Button>();
            if (inventoryBtns.Length != 0)
            {
                for(int i = 0; i < inventoryBtns.Length; i++)
                {
                    Destroy(inventoryBtns[i]);
                }
            }
            foreach(Armor a in armors)
            {
                GameObject armor = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                armor.transform.SetParent(GameObject.FindGameObjectWithTag("InventoryUI").transform, false);
            }
            foreach(Weapon w in weapons)
            {
                GameObject weapon = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                weapon.transform.SetParent(GameObject.FindGameObjectWithTag("InventoryUI").transform, false);
            }
            foreach(Potion p in potions)
            {
                GameObject potion = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                potion.transform.SetParent(GameObject.FindGameObjectWithTag("InventoryUI").transform, false);
            }
        }
    }

    public void GetOptions()
    {

    }
}
