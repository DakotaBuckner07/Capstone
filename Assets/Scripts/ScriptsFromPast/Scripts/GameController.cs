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
    public Monster monster;
    private void Start()
    {
        GameObject.FindGameObjectWithTag("MonsterSpawner").GetComponent<MonsterSpawner>().newMonster();
        monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
        deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
        deck.newDeck();
    }
    public void SetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    /* Methods from Previous
    public void TakeTurn()
    {
        if (selectedCard != null) 
        {
            monster.TakeDamage(selectedCard, player.Turn(selectedCard));
        }
        else
        {
            Debug.Log("No card selected");
            return;
        }
        selectedCard = null;
        if (monster.Health <= 0)
        {
            Debug.Log("Monster has dead");
            player.Coins = Utilities.GetRandNumTimesLevel(3, 10);
            monster.newMonster();
            monster.UpdateMonsterUI();
        }
        else
        {
            player.TakeDamage(monster.Attack(), monster.getElement);
        }
        if(player.Health <= 0)
        {
            gameOverScreen.SetActive(true);
        }
        player.UpdatePlayerUI();
    }

    public void SetSelectedCard(Image i)
    {
        if(player == null)SetPlayer();
        //selectedCard = Utilities.GetCardFromSprite(i.sprite, player.GetHand);
    }
    */
    public void HealPlayer()
    {
        player.Heal(Utilities.GetRandNumTimesLevel(10, 30));
    }

    public void UseRandomDamagePotion()
    {
        monster.TakeDamage(new DamagePotion(Utilities.GetRandomElement(), Utilities.GetRandNumTimesLevel(5, 10), 0));
        //TakeTurn();
    }
}