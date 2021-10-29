using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToProjectile : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (!player.ableToUseCard) return;
        Debug.Log("Getting here");
        if(collision.gameObject.GetComponent<Card>() != null)
        {
            Debug.Log("Getting here too");
            Card c = collision.gameObject.GetComponent<Card>();
            GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>().TakeDamage(c);
            Destroy(collision.gameObject);
            player.ableToUseCard = false;
        }
    }
}
