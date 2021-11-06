using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private List<Material> cardMaterials;
    private List<Card> deck = new List<Card>();
    public List<Card> GetDeck { get => deck; }
    [SerializeField]
    private Transform deckTransform;
    [SerializeField]
    private GameObject cardPrefab;

    public void newDeck()
    {
        int materialIndex = 0;
        deck = new List<Card>();
        for(int i = 0; i <= 3; i++)
        {
            Element e = Element.Air;
            Suit s = Suit.Spades;
            switch (i)
            {
                case 1:
                    e = Element.Earth;
                    s = Suit.Hearts;
                    break;
                case 2:
                    e = Element.Water;
                    s = Suit.Clubs;
                    break;
                case 3:
                    e = Element.Fire;
                    s = Suit.Diamonds;
                    break;
            }
            for(int j = 1; j <= 13; j++)
            {
                Card c = new Card(e, s, j);

                cardPrefab.GetComponent<Card>().SetCard(c.Element, c.Suit, c.Value);
                cardPrefab.GetComponentsInChildren<MeshRenderer>()[0].material = cardMaterials[materialIndex];
                GameObject card = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                card.transform.SetParent(GameObject.FindGameObjectWithTag("Deck").transform, false);

                deck.Add(c);
            }
            materialIndex++;
        }
        Shuffle(2);
    }

    public List<Card> Draw(int numCards)
    {
        List<Card> cards = new List<Card>();
        while(numCards >= 0)
        {
            cards.Add(Draw());
            numCards--;
        }
        return cards;
    }

    public Card Draw()
    {
        if(deck.Count == 0) newDeck();
        Card c = deck[0];
        deck.Remove(c);
        return c;
    }

    private void Shuffle(int numShuffle)
    {
        while(numShuffle > 0)
        {
            Shuffle();
            numShuffle--;
        }
    }

    private void Shuffle()
    {
        for(int i = 516; i > 0; i--)
        {
            Swap(Random.Range(0, 52), Random.Range(0, 52));
        }
    }

    private void Swap(int i, int j)
    {     
        Card temp = deck[i];
        deck[i] = deck[j];
        deck[j] = temp;
    }
}