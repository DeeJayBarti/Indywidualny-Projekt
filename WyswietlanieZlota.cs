using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyswietlanieZlota : MonoBehaviour {

    public UnityEngine.UI.Text Ilosc_Zlota;
    public float gold = 0.00f;

    void Start()
    {
        StartCoroutine(AutomatycznyTick());
    }

    void Update()
    {
        Ilosc_Zlota.text = "" + gold.ToString("F0");
    }

    void Ilosc_Zlota_Na_Sekunde()
    {
        gold += 5;
    }

    IEnumerator AutomatycznyTick()
    {
        while (true)
        {
            Ilosc_Zlota_Na_Sekunde();
            yield return new WaitForSeconds(2.00f);
        }
    }
}
