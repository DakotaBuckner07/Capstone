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
        if (!collision.gameObject.GetComponent<Item>().isBought)
        {
            Destroy(collision.gameObject, 0);
            return;
        }
        if (collision.gameObject.GetComponent<Weapon>() != null)
        {
            Weapon w = collision.gameObject.GetComponent<Weapon>();

            player.EquipWeapon(w);
        }
        else if (collision.gameObject.GetComponent<Shield>() != null)
        {
            Shield s = collision.gameObject.GetComponent<Shield>();

            player.EquipShield(s);
        }
        else
        {
            Destroy(collision.gameObject, 0);
        }
    }
}
