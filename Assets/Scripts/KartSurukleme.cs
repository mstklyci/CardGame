using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartSurukleme : MonoBehaviour
{
    //OyuncuSecim
    private static Camera[] cam;
    public static string currentPlayer = "1";

    public static GameObject secilenKart = null;
    void Start()
    {
        cam = new Camera[4];
        cam[0] = GameObject.Find("Oyuncu1Kamera").GetComponent<Camera>();
        cam[1] = GameObject.Find("Oyuncu2Kamera").GetComponent<Camera>();
        cam[2] = GameObject.Find("Oyuncu3Kamera").GetComponent<Camera>();
        cam[3] = GameObject.Find("Oyuncu4Kamera").GetComponent<Camera>();

        SetCurrentPlayer(currentPlayer);
    }

    public static void SetCurrentPlayer(string player)
    {
        currentPlayer = player;
        int playerNumber = int.Parse(player) - 1;

        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].enabled = (i == playerNumber);
        }
    }

    void Update()
    {
        Camera currentCam = cam[int.Parse(currentPlayer) - 1];
        UpdateTagBasedOnPosition();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = currentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if ((currentPlayer == "1" && hit.collider.CompareTag("1.OyuncuKart")) ||
                    (currentPlayer == "2" && hit.collider.CompareTag("2.OyuncuKart")) ||
                    (currentPlayer == "3" && hit.collider.CompareTag("3.OyuncuKart")) ||
                    (currentPlayer == "4" && hit.collider.CompareTag("4.OyuncuKart")))
                {
                    if (secilenKart != null)
                    {
                        secilenKart.GetComponent<Renderer>().material.color = Color.white;
                    }

                    secilenKart = hit.collider.gameObject;
                    secilenKart.GetComponent<Renderer>().material.color = Color.green;
                }            
            }
        }
    }

    void UpdateTagBasedOnPosition()
    {
        if (gameObject != null)
        {
            if (gameObject.transform.position.x > -0.1f && gameObject.transform.position.x < 0.1f &&
                gameObject.transform.position.z > -0.1f && gameObject.transform.position.z < 0.1f)
            {
                gameObject.tag = "Orta";
            }
            else if (gameObject.transform.position.x > -0.5f && gameObject.transform.position.x < 0.5f &&
                gameObject.transform.position.z > 1f && gameObject.transform.position.z < 1.45f)
            {
                gameObject.tag = "1.OyuncuKart";
            }
            else if (gameObject.transform.position.x > 1f && gameObject.transform.position.x < 1.45f &&
                gameObject.transform.position.z > -0.5f && gameObject.transform.position.z < 0.5f)
            {
                gameObject.tag = "2.OyuncuKart";
            }
            else if (gameObject.transform.position.x > -0.5f && gameObject.transform.position.x < 0.5f &&
                gameObject.transform.position.z > -1.45f && gameObject.transform.position.z < -1f)
            {
                gameObject.tag = "3.OyuncuKart";
            }
            else if (gameObject.transform.position.x > -1.45f && gameObject.transform.position.x < -1f &&
                gameObject.transform.position.z > -0.5f && gameObject.transform.position.z < 0.5f)
            {
                gameObject.tag = "4.OyuncuKart";
            }
        }           
    }
}