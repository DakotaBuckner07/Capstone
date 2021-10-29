using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text coinsTxt;
    public Text healthTxt;
    public Slider healthbar;

    public void UpdatePlayerUI(int health, int maxHealth, List<Card> hand, int coins)
    {
        UpdateHealthUI(health, maxHealth);
        //UpdateHandUI(hand);
        coinsTxt.text = "" + coins + " coins";
    }

    public void UpdateHealthUI(int health, int maxHealth)
    {
        healthbar.maxValue = maxHealth;
        healthTxt.text = health + "/" + maxHealth;
        healthbar.value = health;
        healthbar.minValue = 0;
    }
    /*Hand UI For 2D Canvas
    public void UpdateHandUI(List<Card> hand)
    {
        foreach (Transform child in handUI.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Card c in hand)
        {
            for (int i = 0; i < cardImages.Count; i++)
            {
                if (cardImages[i].name.Contains(c.Suit.ToString()))
                {
                    if (cardImages[i].name.Contains(c.Value.ToString()))
                    {
                        cardPrefab.GetComponent<Image>().sprite = cardImages[i];
                        break;
                    }
                    else if (c.Value == 1 && cardImages[i].name.EndsWith("A"))
                    {
                        cardPrefab.GetComponent<Image>().sprite = cardImages[i];
                        break;
                    }
                    else if (c.Value == 11 && cardImages[i].name.EndsWith("J"))
                    {
                        cardPrefab.GetComponent<Image>().sprite = cardImages[i];
                        break;
                    }
                    else if (c.Value == 12 && cardImages[i].name.EndsWith("Q"))
                    {
                        cardPrefab.GetComponent<Image>().sprite = cardImages[i];
                        break;
                    }
                    else if (c.Value == 13 && cardImages[i].name.EndsWith("K"))
                    {
                        cardPrefab.GetComponent<Image>().sprite = cardImages[i];
                        break;
                    }
                }
            }
            GameObject newCard = cardPrefab;
            GameObject card = Instantiate(newCard, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            //This line sets the button onClick to the right GameController. I hate this line.
            //card.GetComponent<Button>().onClick.AddListener(delegate { GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().SetSelectedCard(card.GetComponent<Image>()); });

            card.transform.SetParent(GameObject.FindGameObjectWithTag("HandUI").transform, false);
        }
    }
    */
}