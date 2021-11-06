using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquipCollider : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Weapon>() != null)
        {
            Weapon w = collision.gameObject.GetComponent<Weapon>();

            //For Test
            w.changeWeapon();

            player.EquipWeapon(w);
        }
        else if (collision.gameObject.GetComponent<Shield>() != null)
        {
            Shield s = collision.gameObject.GetComponent<Shield>();

            //For Test
            s.changeShield();

            player.EquipShield(s);
        }
    }
}
