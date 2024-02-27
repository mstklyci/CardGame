using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KartAlanlari : MonoBehaviour
{

    public GameObject Oyuncu1KartAlani;
    public GameObject Oyuncu2KartAlani;
    public GameObject Oyuncu3KartAlani;
    public GameObject Oyuncu4KartAlani;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    KartTeleportla();
                }
            }
        }
    }
    private void KartTeleportla()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Orta");

        if (allObjects.Length > 0)
        {
            int randomIndex = Random.Range(0, allObjects.Length);
            GameObject randomObject = allObjects[randomIndex];

            if (KartSurukleme.currentPlayer == "1" && TurBelirleme.KartAldi == false)
            {
                randomObject.transform.position = Oyuncu1KartAlani.transform.position;
                randomObject.transform.rotation = Oyuncu1KartAlani.transform.rotation;
                TurBelirleme.KartAldi = true;
            }
            if (KartSurukleme.currentPlayer == "2" && TurBelirleme.KartAldi == false)
            {
                randomObject.transform.position = Oyuncu2KartAlani.transform.position;
                randomObject.transform.rotation = Oyuncu2KartAlani.transform.rotation;
                TurBelirleme.KartAldi = true;
            }
            if (KartSurukleme.currentPlayer == "3" && TurBelirleme.KartAldi == false)
            {
                randomObject.transform.position = Oyuncu3KartAlani.transform.position;
                randomObject.transform.rotation = Oyuncu3KartAlani.transform.rotation;
                TurBelirleme.KartAldi = true;
            }
            if (KartSurukleme.currentPlayer == "4" && TurBelirleme.KartAldi == false)
            {
                randomObject.transform.position = Oyuncu4KartAlani.transform.position;
                randomObject.transform.rotation = Oyuncu4KartAlani.transform.rotation;
                TurBelirleme.KartAldi = true;
            }
        }
    }
}