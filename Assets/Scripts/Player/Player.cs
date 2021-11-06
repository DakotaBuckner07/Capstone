using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    private int maxHealth = 100;
    private int health;
    private int coins;

    private Deck deck;
    private ResistancePotion resistPotion;
    private Weapon equippedWeapon;
    private Shield equippedShield;

    private List<Card> hand;
    //private PlayerUI playerUI;

    public List<Card> GetHand { get => hand; }
    public int Health { get => health; }
    public int Coins { get => coins; set { coins += value; } }
    public Weapon GetWeapon { get => equippedWeapon; }
    public Shield GetShield { get => equippedShield; }
    public int damage = 2;
    public int resistance = 0;
    public bool ableToUseCard = true;

    [SerializeField]
    private float projectileTimer = 5.0f;
    #endregion
    void Start()
    {
        health = maxHealth;
        deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
        hand = deck.Draw(5);
        ableToUseCard = true;
        UpdatePlayerUI();
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
        UpdatePlayerUI();
    }

    public void DrawCard()
    {
        hand.Add(deck.Draw());
        UpdatePlayerUI();
    }

    public void Heal(int heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
        UpdatePlayerUI();
    }

    public void UseResistancePotion(ResistancePotion resistancePotion)
    {
        resistPotion = resistancePotion;
        Debug.Log("Player is currently resistant to " + resistancePotion.Element.ToString());
    }

    #region inventory
    public void EquipShield(Shield shield)
    {
        equippedShield = shield;
        Debug.Log("Player has equipped a " + shield.Element.ToString() + " shield with a resistance of " + shield.Resistance);
    }
    public void EquipWeapon(Weapon weapon)
    {
        equippedWeapon = weapon;
        Debug.Log("Player has equipped a " + weapon.Element.ToString() + " weapon with a bonus of " + weapon.Damage);
    }
    #endregion

    public void UpdatePlayerUI()
    {
        //playerUI.UpdatePlayerUI(Health, maxHealth, hand, coins);
    }
}
