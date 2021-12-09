using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemCollider : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthPotion>() != null)
        {
            HealthPotion hpPot = collision.gameObject.GetComponent<HealthPotion>();
            if (player.Coins >= hpPot.Price)
            {
                player.Coins -= hpPot.Price;
                hpPot.BuyItem();
            }
        }
        else if (collision.gameObject.GetComponent<DamagePotion>() != null)
        {
            DamagePotion dmgPot = collision.gameObject.GetComponent<DamagePotion>();
            if (player.Coins >= dmgPot.Price)
            {
                player.Coins -= dmgPot.Price;
                dmgPot.BuyItem();
            }
        }
        else if (collision.gameObject.GetComponent<ResistancePotion>() != null)
        {
            ResistancePotion resPot = collision.gameObject.GetComponent<ResistancePotion>();
            if (player.Coins >= resPot.Price)
            {
                player.Coins -= resPot.Price;
                resPot.BuyItem();
            }
        }
        else if (collision.gameObject.GetComponent<Shield>() != null)
        {
            Shield shield = collision.gameObject.GetComponent<Shield>();
            if (player.Coins >= shield.Price)
            {
                player.Coins -= shield.Price;
                shield.BuyItem();
            }
        }
        else if (collision.gameObject.GetComponent<Weapon>() != null)
        {
            Weapon weapon = collision.gameObject.GetComponent<Weapon>();
            if (player.Coins >= weapon.Price)
            {
                player.Coins -= weapon.Price;
                weapon.BuyItem();
            }
        }
    }

}
