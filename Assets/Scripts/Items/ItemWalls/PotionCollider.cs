using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollider : MonoBehaviour
{
    private Player player;
    private Monster monster;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<ResistancePotion>() != null)
        {
            Debug.Log("Resistance Potion Used");
            ResistancePotion r = collision.gameObject.GetComponent<ResistancePotion>();

            //For Test
            r.changePotion();

            r.Use();
            player.UseResistancePotion(r); 
            Destroy(collision.gameObject, r.Duration);
        }
        else if(collision.gameObject.GetComponent<DamagePotion>() != null)
        {
            Debug.Log("Damage Potion Used");
            DamagePotion d = collision.gameObject.GetComponent<DamagePotion>();

            //For Test
            d.changePotion();

            monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
            monster.TakeDamage(d);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.GetComponent<HealthPotion>() != null)
        {
            Debug.Log("Health Potion Used");
            HealthPotion h = collision.gameObject.GetComponent<HealthPotion>();

            //For Test
            h.changePotion();

            player.Heal(h.Value);
            Destroy(collision.gameObject);
        }
    }
}
