using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int maxHealth = 100;
    private int health;
    private int coins;

    private Deck deck;
    private ResistancePot resistPotion;
    private Weapon equippedWeapon;
    private Armor equippedArmor;

    private List<Card> hand;
    private PlayerUI playerUI;

    public List<Card> GetHand { get => hand; }
    public int Health { get => health; }
    public int Coins { get => coins; set { coins += value; } }
    public int damage = 2;
    public int resistance = 0;

    private float projectileTimer = 5.0f;
    private bool ableToUseCard = true;

    void Start()
    {
        playerUI = GetComponentInChildren<PlayerUI>();
        health = maxHealth;
        deck = new Deck();
        deck.newDeck();
        hand = deck.Draw(5);
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
        if(equippedArmor != null)
        {
            if(Utilities.CheckElements(equippedArmor.Element, e) == 1)
            {
                currResistance += equippedArmor.Resistance * 2;
            }
            else if(Utilities.CheckElements(equippedArmor.Element, e) != -1)
            {
                currResistance += equippedArmor.Resistance;
            }
        }
        if (resistPotion != null && resistPotion.Duration > 0 && Utilities.CheckElements(resistPotion.Element, e) == 1)
        {
            currResistance += resistPotion.Resistance;
        }
        if (dmg <= currResistance) return;
        health -= (dmg - resistance);
        Debug.Log("Monster delt " + (dmg - resistance) + " damage");
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

    public int Turn(Card c)
    {
        ableToUseCard = false;
        int value = c.Value;
        hand.Remove(c);
        DrawCard();
        if (equippedWeapon != null) return value + equippedWeapon.Damage;
        return value;
    }

    #region inventory
    public void EquipArmor(Armor armor)
    {
        equippedArmor = armor;
    }
    public void EquipWeapon(Weapon weapon)
    {
        equippedWeapon = weapon;
    }
    #endregion

    public void UpdatePlayerUI()
    {
        playerUI.UpdatePlayerUI(Health, maxHealth, hand, coins);
    }
}
