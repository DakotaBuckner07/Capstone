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
        maxHealth = Utilities.newMonsterHealth();
        health = maxHealth;
        element = Utilities.GetRandomElement();
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
        Debug.Log(health);
        if(health <= 0)
        {
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
        UpdateMonsterUI();
    }

    public void UpdateMonsterUI()
    {
        //healthbar.maxValue = maxHealth;
        //healthbar.value = health;
    }
}
