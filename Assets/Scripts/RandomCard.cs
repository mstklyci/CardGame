using System.Collections.Generic;
using UnityEngine;

public class CardPlacer : MonoBehaviour
{
    public Transform[] player1Positions;
    public Transform[] player2Positions;
    public Transform[] player3Positions;
    public Transform[] player4Positions;

    private string[] cardNames = { "Card_Heart2", "Card_Heart3", "Card_Heart4", "Card_Heart5", "Card_Heart6", "Card_Heart7", "Card_Heart8",
                                 "Card_Heart9", "Card_Heart10" , "Card_HeartJack" , "Card_HeartQueen", "Card_HeartKing", "Card_HeartAce",

                                 "Card_Club2", "Card_Club3", "Card_Clubt4", "Card_Club5", "Card_Club6", "Card_Club7", "Card_Club8",
                                 "Card_Club9", "Card_Club10" , "Card_ClubJack" , "Card_ClubQueen", "Card_ClubKing", "Card_ClubAce",

                                 "Card_Diamond2", "Card_Diamond3", "Card_Diamond4", "Card_Diamond5", "Card_Diamond6", "Card_Diamond7", "Card_Diamond8",
                                 "Card_Diamond9", "Card_Diamond10" , "Card_DiamondJack" , "Card_DiamondQueen", "Card_DiamondKing", "Card_DiamondAce",

                                 "Card_Spade2", "Card_Spade3", "Card_Spade4", "Card_Spade5", "Card_Spade6", "Card_Spade7", "Card_Spade8",
                                 "Card_Spade9", "Card_Spade10" , "Card_SpadeJack" , "Card_SpadeQueen", "Card_SpadeKing", "Card_SpadeAce"};
    void Start()
    {
        PlaceCards();
    }

    void PlaceCards()
    {
        List<GameObject> availableCards = new List<GameObject>();

        foreach (string cardName in cardNames)
        {
            GameObject card = GameObject.Find(cardName);
            if (card != null)
            {
                availableCards.Add(card);
            }
        }

        PlaceCardsForPlayer(player1Positions, availableCards);
        PlaceCardsForPlayer(player2Positions, availableCards);
        PlaceCardsForPlayer(player3Positions, availableCards);
        PlaceCardsForPlayer(player4Positions, availableCards);
    }

    void PlaceCardsForPlayer(Transform[] positions, List<GameObject> availableCards)
    {
        int numCardsToPlace = Mathf.Min(7, positions.Length);

        for (int i = 0; i < numCardsToPlace; i++)
        {
            if (availableCards.Count == 0) return;

            int randomIndex = Random.Range(0, availableCards.Count);
            GameObject card = availableCards[randomIndex];
            card.transform.position = positions[i].position;
            card.transform.rotation = positions[i].rotation;

            availableCards.RemoveAt(randomIndex);
        }
    }
}