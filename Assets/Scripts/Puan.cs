using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Puan : MonoBehaviour
{

    private Dictionary<string, int> cardValues = new Dictionary<string, int>()
    {
        {"Card_Heart2", 2}, {"Card_Heart3", 3}, {"Card_Heart4", 4}, {"Card_Heart5", 5}, {"Card_Heart6", 6}, {"Card_Heart7", 7}, {"Card_Heart8", 8},
        {"Card_Heart9", 9}, {"Card_Heart10", 10}, {"Card_HeartJack", 10}, {"Card_HeartQueen", 10}, {"Card_HeartKing", 10}, {"Card_HeartAce", 10},

        {"Card_Club2", 2}, {"Card_Club3", 3}, {"Card_Club4", 4}, {"Card_Club5", 5}, {"Card_Club6", 6}, {"Card_Club7", 7}, {"Card_Club8", 8},
        {"Card_Club9", 9}, {"Card_Club10", 10}, {"Card_ClubJack", 10}, {"Card_ClubQueen", 10}, {"Card_ClubKing", 10}, {"Card_ClubAce", 10},

        {"Card_Diamond2", 2}, {"Card_Diamond3", 3}, {"Card_Diamond4", 4}, {"Card_Diamond5", 5}, {"Card_Diamond6", 6}, {"Card_Diamond7", 7}, {"Card_Diamond8", 8},
        {"Card_Diamond9", 9}, {"Card_Diamond10", 10}, {"Card_DiamondJack", 10}, {"Card_DiamondQueen", 10}, {"Card_DiamondKing", 10}, {"Card_DiamondAce", 10},

        {"Card_Spade2", 2}, {"Card_Spade3", 3}, {"Card_Spade4", 4}, {"Card_Spade5", 5}, {"Card_Spade6", 6}, {"Card_Spade7", 7}, {"Card_Spade8", 8},
        {"Card_Spade9", 9}, {"Card_Spade10", 10} , {"Card_SpadeJack", 10}, {"Card_SpadeQueen",10}, {"Card_SpadeKing",10}, {"Card_SpadeAce",10}
    };

    void Update()
    {
        GameObject middleObject = GameObject.FindWithTag("Orta");

        if (middleObject == null)
        {
            GameObject[] player1Cards = GameObject.FindGameObjectsWithTag("1.OyuncuKart");
            GameObject[] player2Cards = GameObject.FindGameObjectsWithTag("2.OyuncuKart");
            GameObject[] player3Cards = GameObject.FindGameObjectsWithTag("3.OyuncuKart");
            GameObject[] player4Cards = GameObject.FindGameObjectsWithTag("4.OyuncuKart");

            Dictionary<int, int> playerScores = new Dictionary<int, int>
        {
            {1, CalculateScore(player1Cards)},
            {2, CalculateScore(player2Cards)},
            {3, CalculateScore(player3Cards)},
            {4, CalculateScore(player4Cards)}
        };

            int lowestScore = playerScores.Values.Min();
            int lowestScorePlayer = playerScores.FirstOrDefault(x => x.Value == lowestScore).Key;

            Debug.Log("En Düþük Puan: " + lowestScore + ", Oyuncu: " + lowestScorePlayer + " Kazandi");

            foreach (var playerScore in playerScores)
            {
                Debug.Log(playerScore.Key + ". Oyuncunun Puaný: " + playerScore.Value);
            }
        }
    }

    int CalculateScore(GameObject[] cards)
    {
        int score = 0;
        foreach (GameObject card in cards)
        {
            if (cardValues.TryGetValue(card.name, out int cardValue))
            {
                score += cardValue;
            }
            else
            {
                Debug.LogWarning("Kart bulunamadý: " + card.name);
            }
        }
        return score;
    }
}