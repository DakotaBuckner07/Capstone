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
    private float attackTimer = 5.0f;

    private GameController gameController;

    public int Health { get => health; }
    public Element getElement { get => element; }

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void newMonster()
    {
        newMonster(Utilities.GetRandomElement());
    }

    public void newMonster(Element e)
    {
        maxHealth = Utilities.newMonsterHealth();
        health = maxHealth;
        element = e;
        Debug.Log(maxHealth);
        UpdateMonsterUI();
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if(attackTimer <= 0)
        {
            gameController.MonsterAttack();
            attackTimer = 5.0f / Utilities.OverallLevel;
        }
    }

    public void TakeDamage(Card c, Weapon w)
    {
        if (w == null)
        {
            TakeDamage(c);
            return;
        }

        int weakness = Utilities.CheckElements(element, w.Element);
        if (weakness == 1)
        {
            TakeDamage(c, w.Damage * 2);
            Debug.Log("Enemy is Weak to player's " + w.Element.ToString() + " weapon.");
        }
        else if (weakness == -1)
        {
            TakeDamage(c, w.Damage / 2);
            Debug.Log("Enemy is Strong against player's " + w.Element.ToString() + " weapon.");
        }
        else
        {
            TakeDamage(c, w.Damage);
        }
    }

    public void TakeDamage(Card c, int bonus = 0)
    {
        int weakness = Utilities.CheckElements(element, c.Element);
        int damage = c.Value;
        if (weakness == 1)
        {
            damage *= 2;
            Debug.Log("Enemy is Weak to the " + c.Suit.ToString() + " card.");
        }
        else if (weakness == -1)
        {
            damage /= 2;
            Debug.Log("Enemy is Strong against the " + c.Suit.ToString() + " card.");
        }
        health -= damage + bonus;
        Debug.Log("Player delt " + damage + " damage with a weapon bonus of " + bonus + " using a card.");
        Debug.Log("Monster has " + health + " health left");
        if(health <= 0)
        {
            gameController.player.Coins = Random.Range(Utilities.GetRandNumTimesLevel(3, 5), maxHealth);
            gameController.newMonster();
            Destroy(gameObject, 0);
            newMonster();
        }
        UpdateMonsterUI();
    }

    public void TakeDamage(DamagePotion p)
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
        Debug.Log("Monster has " + health + " health left");
        UpdateMonsterUI();
    }

    public void UpdateMonsterUI()
    {
        //healthbar.maxValue = maxHealth;
        //healthbar.value = health;
    }
}
