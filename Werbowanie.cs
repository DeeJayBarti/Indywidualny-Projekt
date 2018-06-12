using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werbowanie : MonoBehaviour {

    //----------------------- TWORZENIE GAME OBJECTOW ---------------------------
    public GameObject Warrior;
    public GameObject Orc;

    private int respawns = 0;
    public float RespawnsSpeed = 12.0f;

    void Start ()
    {
       //StartCoroutine(RespawnEnemy());
    }
	
	void Update ()
    {

    }

    // ---------------------- FUNKCJA WERBOWANIA WOJOWNIKA -------------------------
    public void Werbuj_Wojownika()
    {
        Debug.Log("Zwerbowano wojownika !");
        Instantiate(Warrior, new Vector3(-6, -3.4f, 0), Quaternion.identity);
    }
    
    //----------------------- FUNKCJA WERBOWANIA ORKA ------------------------------
    public void Werbuj_Orka()
    {

        Debug.Log("Zwerbowano orka !");
        Instantiate(Orc, new Vector3(6, -3.4f, 0), Quaternion.identity);
    }

    //---------------------- FUNKCJA WERBOWANIA ORKA CO 4 SEKUNDY --------------------

    IEnumerator RespawnEnemy()
    {
        while(respawns < 999)
        {
            Werbuj_Orka();
            respawns++;
            yield return new WaitForSeconds(RespawnsSpeed);
        }
    }
}
