using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Slider healthbar;

    private int maxHealth;
    private int health;
    private Element element;

    public int Health { get => health; }
    public Element getElement { get => element; }

    private void Start()
    {
        newMonster();
    }

    public void newMonster()
    {
        maxHealth = Utilities.newMonsterHealth();
        health = maxHealth;
        element = Utilities.GetRandomElement();
        UpdateMonsterUI();
    }

    public int Attack()
    {
        return Utilities.GetRandNumTimesLevel(5, 20);
    }

    public void TakeDamage(Card c, int bonus = 0)
    {
        int weakness = Utilities.CheckElements(element, c.Element);
        int damage = c.Value;
        if (weakness == 1)
        {
            damage *= 2;
            Debug.Log("Enemy is Weak to " + c.Suit.ToString());
        }
        else if (weakness == -1)
        {
            damage /= 2;
            Debug.Log("Enemy is Strong against " + c.Suit.ToString());
        }
        health -= damage + bonus;
        Debug.Log("Player delt " + (damage + bonus) + " damage using a card");
        UpdateMonsterUI();
    }

    public void TakeDamage(ElementPot p)
    {
        int weakness = Utilities.CheckElements(element, p.Element);
        int damage = p.Value;
        if (weakness == 1)
        {
            damage *= 2;
            Debug.Log("Enemy is Weak to " + p.Element.ToString());
        }
        else if (weakness == -1)
        {
            damage /= 2;
            Debug.Log("Enemy is Strong against " + p.Element.ToString());
        }
        health -= damage;
        Debug.Log("Player delt " + damage + " damage using a potion");
        UpdateMonsterUI();
    }

    public void UpdateMonsterUI()
    {
        healthbar.maxValue = maxHealth;
        healthbar.value = health;
    }
}
