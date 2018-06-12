using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptKoszary : MonoBehaviour {

    public UnityEngine.UI.Text Opis;
    public float KosztZakupu = 200;
    public float KosztUlepszenia = 500;

    private float BasicAttackWarrior = 50;
    private float BasicHealthWarrior = 150;

    private float NewAttackWarrior;
    private float NewHealthWarrior;

    public bool ulepszono = false;
    private int liczbaUlepszen = 0;

    void Start ()
    {

    }
	
	void Update ()
    {
        Opis.text = "\nZycie: " + BasicHealthWarrior + "\nAtak: " + BasicAttackWarrior + "\nKoszt: " + KosztZakupu;
        SprawdzCzyUlepszono();
    }

    public void KupPrzedmiot()
    {
        WyswietlanieZlota WZ = GameObject.FindObjectOfType<WyswietlanieZlota>();
        Werbowanie Wer = GameObject.FindObjectOfType<Werbowanie>();
        if (WZ.gold >= KosztZakupu)
        {
            WZ.gold -= KosztZakupu;
            Wer.Werbuj_Wojownika();
        }
    }

    public void UlepszJednostke()
    {
        SkryptWojownik SW = FindObjectOfType<SkryptWojownik>();
        WyswietlanieZlota WZ = GameObject.FindObjectOfType<WyswietlanieZlota>();
        if (WZ.gold >= KosztUlepszenia)
        {
            WZ.gold -= KosztUlepszenia;
            BasicAttackWarrior += 30;
            BasicHealthWarrior += 50;


            SW.HealthWarrior += 50;
            SW.AttackWarrior += 30;
            ulepszono = true;
            liczbaUlepszen++;
        }

    }

    public void SprawdzCzyUlepszono()
    {
        foreach (GameObject Warrior in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            SkryptWojownik SW = FindObjectOfType<SkryptWojownik>();
            if (Warrior.tag == "Friend" && ulepszono == true)
            {
                if(SW.AttackWarrior == 50 && SW.HealthWarrior == 150 && liczbaUlepszen == 1)
                {
                   Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 30;
                   Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 50;
                }
                else if(SW.AttackWarrior == 80 && SW.HealthWarrior == 200 && liczbaUlepszen == 2)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 30;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 50;
                }
                else if (SW.AttackWarrior == 50 && SW.HealthWarrior == 150 && liczbaUlepszen == 2)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 60;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 100;
                }
                else if (SW.AttackWarrior == 110 && SW.HealthWarrior == 250 && liczbaUlepszen == 3)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 30;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 50;
                }
                else if (SW.AttackWarrior == 50 && SW.HealthWarrior == 150 && liczbaUlepszen == 3)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 90;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 150;
                }
                else if (SW.AttackWarrior == 140 && SW.HealthWarrior == 300 && liczbaUlepszen == 4)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 30;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 50;
                }
                else if (SW.AttackWarrior == 50 && SW.HealthWarrior == 150 && liczbaUlepszen == 4)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 120;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 200;
                }
                else if (SW.AttackWarrior == 170 && SW.HealthWarrior == 350 && liczbaUlepszen == 5)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 30;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 50;
                }
                else if (SW.AttackWarrior == 50 && SW.HealthWarrior == 150 && liczbaUlepszen == 5)
                {
                    Warrior.GetComponent<SkryptWojownik>().AttackWarrior += 150;
                    Warrior.GetComponent<SkryptWojownik>().HealthWarrior += 250;
                }
            }
        }
    }
}
