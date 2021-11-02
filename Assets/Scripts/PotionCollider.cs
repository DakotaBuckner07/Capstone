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
        Debug.Log("Starting");
        if(collision.gameObject.GetComponent<ResistancePotion>() != null)
        {
            Debug.Log("Resistance");

        }
        else if(collision.gameObject.GetComponent<DamagePotion>() != null)
        {
            Debug.Log("Damage");
            monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
            monster.TakeDamage(collision.gameObject.GetComponent<DamagePotion>());
        }
        else if(collision.gameObject.GetComponent<HealthPotion>() != null)
        {
            Debug.Log("Health");
            player.Heal(collision.gameObject.GetComponent<HealthPotion>().healAmount());
        }
        Destroy(collision.gameObject, 1);
    }
}
