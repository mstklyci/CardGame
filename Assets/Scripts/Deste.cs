using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deste : MonoBehaviour
{

    public Transform[] cardPositions;
    public string PlayerTargetTag;

    private bool calis = true;

    void Update()
    {
        if (calis)
        {
            StartCoroutine(DelayFirstUpdate(1f));
            calis = false;
        }
        else
        {
            UpdateCards();
        }
    }

    IEnumerator DelayFirstUpdate(float delay)
    {
        yield return new WaitForSeconds(delay);
        UpdateCards();
    }

    void UpdateCards()
    {
        System.Array.Sort(cardPositions, ComparePositions);

        for (int i = 0; i < cardPositions.Length - 1; i++)
        {
            GameObject[] currentCards = GetCardsInPosition(cardPositions[i]);
            GameObject[] nextCards = GetCardsInPosition(cardPositions[i + 1]);

            if (currentCards.Length == 0 && nextCards.Length > 0)
            {
                MoveCards(nextCards, cardPositions[i]);
            }
        }
    }
    private GameObject[] GetCardsInPosition(Transform position)
    {
        return GameObject.FindGameObjectsWithTag(PlayerTargetTag)
            .Where(card => card.transform.position == position.position)
            .ToArray();
    }

    private void MoveCards(GameObject[] cards, Transform newPosition)
    {
        foreach (GameObject card in cards)
        {
            card.transform.position = newPosition.position;
            card.transform.rotation = newPosition.rotation;
        }
    }

    private int ComparePositions(Transform a, Transform b)
    {
        return a.GetSiblingIndex().CompareTo(b.GetSiblingIndex());
    }
}