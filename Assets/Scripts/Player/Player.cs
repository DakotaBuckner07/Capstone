using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    private int maxHealth = 1000;
    private int health;
    private int coins = 1000;
    [SerializeField]
    private float projectileTimer = 5.0f;

    public int damage = 2;
    public int resistance = 0;
    public bool ableToUseCard = true;

    private Deck deck;
    private ResistancePotion resistPotion;
    private Weapon equippedWeapon;
    private Shield equippedShield;

    private List<Card> hand;
    //private PlayerUI playerUI;

    public List<Card> GetHand { get => hand; }
    public int Health { get => health; }
    public int Coins { get => coins; set { coins += value; UpdateMoneyUI(); } }
    public Weapon GetWeapon { get => equippedWeapon; }
    public Shield GetShield { get => equippedShield; }

    #endregion

    #region UI Variables
    private Slider healthBar;
    private Text healthTxt;
    [SerializeField]
    private Text weaponTxt;
    [SerializeField]
    private Text shieldTxt;
    [SerializeField]
    private Text potionTxt;
    [SerializeField]
    private Text coinsTxt;
    [SerializeField]
    private Text cardTimerTxt;
    #endregion

    void Start()
    {
        health = maxHealth;
        deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
        hand = deck.Draw(5);
        ableToUseCard = true;

        healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        healthTxt = healthBar.GetComponentInChildren<Text>();
        healthBar.maxValue = maxHealth;
        UpdateHealthUI();
        UpdateMoneyUI();
    }

    private void Update()
    {
        if (!ableToUseCard)
        {
            projectileTimer -= Time.deltaTime;
            if (projectileTimer <= 0)
            {
                projectileTimer = 5.0f;
                ableToUseCard = true;
            }
        }
        if (resistPotion != null) UpdatePotionUI();
        if (ableToUseCard == false) UpdateCardUI();
    }

    public void TakeDamage(int dmg, Element e)
    {
        int currResistance = resistance;
        if(equippedShield != null)
        {
            if(Utilities.CheckElements(equippedShield.Element, e) == 1)
            {
                currResistance += equippedShield.Resistance * 2;
                Debug.Log("Shield resisted by " + equippedShield.Resistance * 2);
            }
            else if(Utilities.CheckElements(equippedShield.Element, e) != -1)
            {
                currResistance += equippedShield.Resistance;
                Debug.Log("Shield resisted by " + equippedShield.Resistance);
                Debug.Log("Monster should have delt " + dmg);
            }
        }
        if (resistPotion != null && Utilities.CheckElements(resistPotion.Element, e) == 1)
        {
            currResistance += resistPotion.Resistance;
            Debug.Log("Player is resistant to " + resistPotion.Element.ToString());
        }
        if (dmg <= currResistance) return;
        health -= (dmg - currResistance);
        Debug.Log("Monster delt " + (dmg - currResistance) + " damage");
        UpdateHealthUI();
    }

    #region Potions
    public void Heal(int heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
        UpdateHealthUI();
    }

    public void UseResistancePotion(ResistancePotion resistancePotion)
    {
        resistPotion = resistancePotion;
        UpdatePotionUI();
        Debug.Log("Player is currently resistant to " + resistancePotion.Element.ToString() + " for " + resistPotion.Duration + " seconds.");
    }
    #endregion
    #region Inventory
    public void EquipShield(Shield shield)
    {
        equippedShield = shield;
        UpdateEquipmentUI();
        Debug.Log("Player has equipped a " + shield.Element.ToString() + " shield with a resistance of " + shield.Resistance);
    }
    public void EquipWeapon(Weapon weapon)
    {
        equippedWeapon = weapon;
        UpdateEquipmentUI();
        Debug.Log("Player has equipped a " + weapon.Element.ToString() + " weapon with a bonus of " + weapon.Damage);
    }
    #endregion

    #region UI
    private void UpdateMoneyUI()
    {
        coinsTxt.text = coins + " gold";
    }

    private void UpdateHealthUI()
    {
        healthBar.value = (maxHealth - health);
        healthTxt.text = (health + "/" + maxHealth);
    }

    private void UpdatePotionUI()
    {
        if (System.Math.Round(resistPotion.Duration, 2) - .05 >= 0)
        {
            potionTxt.text = "Potion: " +
                "\n" + resistPotion.Element.ToString() +
                "\nResists " + resistPotion.Resistance +
                "\nTime: " + System.Math.Round(resistPotion.Duration, 2);
        }
        else
        {
            potionTxt.text = "Potion: \n None";
        }
    }

    private void UpdateEquipmentUI()
    {
        if (equippedShield != null)
        {
            shieldTxt.text = "Shield: " +
                "\n" + equippedShield.Element.ToString() +
                "\n+" + equippedShield.Resistance + " resistance";
        }
        if(equippedWeapon != null)
        {
            weaponTxt.text = "Weapon: " +
                "\n" + equippedWeapon.Element.ToString() +
                "\n+" + equippedWeapon.Damage + " damage\n";
        }
    }

    private void UpdateCardUI()
    {
        if(System.Math.Round(projectileTimer, 2) - .05 >= 0)
        {
            cardTimerTxt.text = "Use card in: " + System.Math.Round(projectileTimer, 2);
        }
        else
        {
            cardTimerTxt.text = "Use card now";
        }
    }
    #endregion
}
