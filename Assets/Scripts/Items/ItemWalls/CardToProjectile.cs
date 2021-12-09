using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToProjectile : MonoBehaviour
{
    private GameController gc;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gc.player.ableToUseCard) return;
        if (other.gameObject.GetComponent<Card>() != null)
        {
            Card c = other.gameObject.GetComponent<Card>();
            gc.monster.TakeDamage(c, gc.player.GetWeapon);
            Destroy(other.gameObject);
            gc.player.ableToUseCard = false;
        }
    }
}
