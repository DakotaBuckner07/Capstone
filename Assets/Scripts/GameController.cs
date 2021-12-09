using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    private bool paused = false;

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

    public void Pause()
    {
        paused = !paused;
        Time.timeScale = (paused) ? 0.01f : 1;
    }

    public void newMonster()
    {
        monsterSpawner.newMonster();
        monster = GameObject.FindGameObjectWithTag("Animal").GetComponent<Monster>();
    }

    public void MonsterAttack()
    {
        player.TakeDamage(Utilities.GetRandNumTimesLevel(5, 10), monster.getElement);
    }
}