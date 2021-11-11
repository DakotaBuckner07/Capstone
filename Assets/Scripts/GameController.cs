using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;

    public Deck deck;
    public Player player;
    public MonsterSpawner monsterSpawner;
    public Monster monster;

    private void Start()
    {
        monsterSpawner = GameObject.FindGameObjectWithTag("MonsterSpawner").GetComponent<MonsterSpawner>();
        deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        newMonster();
    }

    public void newMonster()
    {
        monsterSpawner.newMonster();
        monster = GameObject.FindGameObjectWithTag("Animal").GetComponent<Monster>();
    }

    public void HealPlayer()
    {
        player.Heal(Utilities.GetRandNumTimesLevel(10, 30));
    }

    public void MonsterAttack()
    {
        player.TakeDamage(Utilities.GetRandNumTimesLevel(5, 10), monster.getElement);
    }
}