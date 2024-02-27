using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yanlar : MonoBehaviour
{
    public string targetTag;

    public GameObject Oyuncu1KartAlani;
    public GameObject Oyuncu2KartAlani;
    public GameObject Oyuncu3KartAlani;
    public GameObject Oyuncu4KartAlani;
    
    private List<GameObject> all1OyuncuKarts = new List<GameObject>();
    private List<GameObject> all2OyuncuKarts = new List<GameObject>();
    private List<GameObject> all3OyuncuKarts = new List<GameObject>();
    private List<GameObject> all4OyuncuKarts = new List<GameObject>();

    private GameObject lastTouched1Object;
    private GameObject lastTouched2Object;
    private GameObject lastTouched3Object;
    private GameObject lastTouched4Object;

    public Vector3 player1StartPosition;
    public Vector3 player2StartPosition;
    public Vector3 player3StartPosition;
    public Vector3 player4StartPosition;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    //KartVerme
                    if (targetTag == "1.OyuncuKart")
                    {
                        if (KartSurukleme.currentPlayer == "1" && TurBelirleme.KartVerdi == false && TurBelirleme.KartAldi == true)
                        {
                            KartSurukleme.secilenKart.transform.position = transform.position;
                            KartSurukleme.secilenKart.transform.rotation = Quaternion.Euler(-90, 45, 0);
                        }
                        if (KartSurukleme.currentPlayer == "2" && TurBelirleme.KartAldi == false)
                        {
                            lastTouched1Object.transform.position = Oyuncu2KartAlani.transform.position;
                            lastTouched1Object.transform.rotation = Oyuncu2KartAlani.transform.rotation;
                            TurBelirleme.KartAldi = true;
                        }
                    }
                    if (targetTag == "2.OyuncuKart")
                    {
                        if (KartSurukleme.currentPlayer == "2" && TurBelirleme.KartVerdi == false && TurBelirleme.KartAldi == true)
                        {
                            KartSurukleme.secilenKart.transform.position = transform.position;
                            KartSurukleme.secilenKart.transform.rotation = Quaternion.Euler(-90, -45, 0);
                        }
                        if (KartSurukleme.currentPlayer == "3" && TurBelirleme.KartAldi == false)
                        {
                            lastTouched2Object.transform.position = Oyuncu3KartAlani.transform.position;
                            lastTouched2Object.transform.rotation = Oyuncu3KartAlani.transform.rotation;
                            TurBelirleme.KartAldi = true;
                        }
                    }
                    if (targetTag == "3.OyuncuKart")
                    {
                        if (KartSurukleme.currentPlayer == "3" && TurBelirleme.KartVerdi == false && TurBelirleme.KartAldi == true)
                        {
                            KartSurukleme.secilenKart.transform.position = transform.position;
                            KartSurukleme.secilenKart.transform.rotation = Quaternion.Euler(-90, 45, 0);
                        }
                        if (KartSurukleme.currentPlayer == "4" && TurBelirleme.KartAldi == false)
                        {
                            lastTouched3Object.transform.position = Oyuncu4KartAlani.transform.position;
                            lastTouched3Object.transform.rotation = Oyuncu4KartAlani.transform.rotation;
                            TurBelirleme.KartAldi = true;
                        }
                    }
                    if (targetTag == "4.OyuncuKart")
                    {
                        if (KartSurukleme.currentPlayer == "4" && TurBelirleme.KartVerdi == false && TurBelirleme.KartAldi == true)
                        {
                            KartSurukleme.secilenKart.transform.position = transform.position;
                            KartSurukleme.secilenKart.transform.rotation = Quaternion.Euler(-90, -45, 0);
                        }
                        if (KartSurukleme.currentPlayer == "1" && TurBelirleme.KartAldi == false)
                        {
                            lastTouched4Object.transform.position = Oyuncu1KartAlani.transform.position;
                            lastTouched4Object.transform.rotation = Oyuncu1KartAlani.transform.rotation;
                            TurBelirleme.KartAldi = true;
                        }
                    }                                                                           
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (targetTag == "1.OyuncuKart")
            {
                if (!all1OyuncuKarts.Contains(other.gameObject))
                {
                    all1OyuncuKarts.Add(other.gameObject);
                    other.gameObject.tag = "Untagged";
                }
                lastTouched1Object = other.gameObject;
                TurBelirleme.KartVerdi = true;
            }
            if (targetTag == "2.OyuncuKart")
            {
                if (!all2OyuncuKarts.Contains(other.gameObject))
                {
                    all2OyuncuKarts.Add(other.gameObject);
                    other.gameObject.tag = "Untagged";
                }
                lastTouched2Object = other.gameObject;
                TurBelirleme.KartVerdi = true;
            }
            if (targetTag == "3.OyuncuKart")
            {
                if (!all3OyuncuKarts.Contains(other.gameObject))
                {
                    all3OyuncuKarts.Add(other.gameObject);
                    other.gameObject.tag = "Untagged";
                }
                lastTouched3Object = other.gameObject;
                TurBelirleme.KartVerdi = true;
            }
            if (targetTag == "4.OyuncuKart")
            {               
                if (!all4OyuncuKarts.Contains(other.gameObject))
                {
                    all4OyuncuKarts.Add(other.gameObject);
                    other.gameObject.tag = "Untagged";
                }
                lastTouched4Object = other.gameObject;
                TurBelirleme.KartVerdi = true;
            }
            if (KartSurukleme.secilenKart == other.gameObject)
            {
                KartSurukleme.secilenKart.GetComponent<Renderer>().material.color = Color.white;
                KartSurukleme.secilenKart = null;
            }
            UpdateKart();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (targetTag == "1.OyuncuKart" && lastTouched1Object == other.gameObject)
        {
            lastTouched1Object = null;
            if (all1OyuncuKarts.Contains(other.gameObject))
            {
                all1OyuncuKarts.Remove(other.gameObject);
            }
        }
        else if (targetTag == "2.OyuncuKart" && lastTouched2Object == other.gameObject)
        {
            lastTouched2Object = null;
            if (all2OyuncuKarts.Contains(other.gameObject))
            {
                all2OyuncuKarts.Remove(other.gameObject);
            }
        }
        else if (targetTag == "3.OyuncuKart" && lastTouched3Object == other.gameObject)
        {
            lastTouched3Object = null;
            if (all3OyuncuKarts.Contains(other.gameObject))
            {
                all3OyuncuKarts.Remove(other.gameObject);
            }
        }
        else if (targetTag == "4.OyuncuKart" && lastTouched4Object == other.gameObject)
        {
            lastTouched4Object = null;
            if (all4OyuncuKarts.Contains(other.gameObject))
            {
                all4OyuncuKarts.Remove(other.gameObject);
            }
        }
    }
    void UpdateKart()
    {
        UpdateKartPositions(all1OyuncuKarts, player2StartPosition);
        UpdateKartPositions(all2OyuncuKarts, player3StartPosition);
        UpdateKartPositions(all3OyuncuKarts, player4StartPosition);
        UpdateKartPositions(all4OyuncuKarts, player1StartPosition);
    }
    private void UpdateKartPositions(List<GameObject> karts, Vector3 startPosition)
    {
        if (karts.Count == 0) return;

        for (int i = 0; i < karts.Count; i++)
        {
            karts[i].transform.position = new Vector3(startPosition.x, startPosition.y + i * 0.003f, startPosition.z);
        }
    }
}