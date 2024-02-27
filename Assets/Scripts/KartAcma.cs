using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KartAcma : MonoBehaviour
{
    public Transform[] targetTransforms;
    private bool[] doluTransformlar;
    private int[] kartDegerleri;

    private Dictionary<string, int> cardValues = new Dictionary<string, int>()
    {
        {"Card_Heart2", 0_2}, {"Card_Heart3", 0_3}, {"Card_Heart4", 0_4}, {"Card_Heart5", 0_5}, {"Card_Heart6", 0_6}, {"Card_Heart7", 0_7}, {"Card_Heart8", 0_8},
        {"Card_Heart9", 0_9}, {"Card_Heart10", 0_10}, {"Card_HeartJack", 0_11}, {"Card_HeartQueen", 0_12}, {"Card_HeartKing", 0_13}, {"Card_HeartAce", 0_14},

        {"Card_Club2", 1_2}, {"Card_Club3", 1_3}, {"Card_Club4", 1_4}, {"Card_Club5", 1_5}, {"Card_Club6", 1_6}, {"Card_Club7", 1_7}, {"Card_Club8", 1_8},
        {"Card_Club9", 1_9}, {"Card_Club10", 1_10}, {"Card_ClubJack", 1_11}, {"Card_ClubQueen", 1_12}, {"Card_ClubKing", 1_13}, {"Card_ClubAce", 1_14},

        {"Card_Diamond2", 2_2}, {"Card_Diamond3", 2_3}, {"Card_Diamond4", 2_4}, {"Card_Diamond5", 2_5}, {"Card_Diamond6", 2_6}, {"Card_Diamond7", 2_7}, {"Card_Diamond8", 2_8},
        {"Card_Diamond9", 2_9}, {"Card_Diamond10", 2_10}, {"Card_DiamondJack", 2_11}, {"Card_DiamondQueen", 2_12}, {"Card_DiamondKing", 2_13}, {"Card_DiamondAce", 2_14},

        {"Card_Spade2", 3_2}, {"Card_Spade3", 3_3}, {"Card_Spade4", 3_4}, {"Card_Spade5", 3_5}, {"Card_Spade6", 3_6}, {"Card_Spade7", 3_7}, {"Card_Spade8", 3_8},
        {"Card_Spade9", 3_9}, {"Card_Spade10", 3_10}, {"Card_SpadeJack", 3_11}, {"Card_SpadeQueen", 3_12}, {"Card_SpadeKing", 3_13}, {"Card_SpadeAce", 3_14}

    }; private void Start()
    {
        doluTransformlar = new bool[targetTransforms.Length];
        kartDegerleri = new int[targetTransforms.Length];
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < targetTransforms.Length; i++)
                {
                    if (hit.transform == targetTransforms[i])
                    {
                        if (!doluTransformlar[i])
                        {
                            KartSurukleme.secilenKart.transform.position = targetTransforms[i].position;
                            KartSurukleme.secilenKart.transform.rotation = Quaternion.Euler(-90, 0, 0);
                            KartSurukleme.secilenKart.tag = "Untagged";

                            if (cardValues.TryGetValue(KartSurukleme.secilenKart.name, out int kartDegeri))
                            {
                                kartDegerleri[i] = kartDegeri;
                            }
                            doluTransformlar[i] = true;

                            SeriKontrolEt();

                            break;
                        }
                    }
                }
            }
        }
    }
    private void SeriKontrolEt()
    {
        for (int i = 0; i < kartDegerleri.Length - 2; i++)
        {
            if (doluTransformlar[i] && doluTransformlar[i + 1] && doluTransformlar[i + 2])
            {
                if ((kartDegerleri[i] + 1 == kartDegerleri[i + 1] && kartDegerleri[i + 1] + 1 == kartDegerleri[i + 2]))
                {
                    Debug.Log("Baþarýlý");
                    
                    return;
                }
                else if ((kartDegerleri[i] % 100 == kartDegerleri[i + 1] % 100 && kartDegerleri[i + 1] % 100 == kartDegerleri[i + 2] % 100))
                {
                    Debug.Log("Baþarýlý");
                }
            }
        }
    }
}