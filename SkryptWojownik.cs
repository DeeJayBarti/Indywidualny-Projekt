using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptWojownik : MonoBehaviour {

    public bool DochodziDoKolizji; // Zmiana animacji z walki na chodzenie
    public Animator AnimacjaWojownika; // Animacja chodzenia
    private bool attack; // Zmienna przy animacji
    private bool isColliding = false; // Zmienna przy kolizji
    public bool IsCollidingWithEnemy = false;

    public float HealthWarrior = 150;
    public float AttackWarrior = 50;
    private int valueOfAttacks = 0;

    public WyswietlanieZlota WZ;

    //----------------------------------------------------------------------------------------------- Funkcja startowa
    void Start()
    {
        AnimacjaWojownika = GetComponent<Animator>();
    }

    //----------------------------------------------------------------------------------------------- Funkcja odświeżania
    void Update()
    {
        if (HealthWarrior <= 0)
        {
            Destroy(gameObject);
        }
    }

    //------------------------------------------------------------------------------------------------ Funkcja gdy dochodzi do kolizji

    void OnTriggerEnter2D(Collider2D OrcCollider) //Kolizja z Orkiem
    {
        if (OrcCollider.gameObject.tag == "Enemy")
        {
            if (!isColliding)
            {
                IsCollidingWithEnemy = true;
                SkryptOrk SO = OrcCollider.gameObject.GetComponent<SkryptOrk>(); // Odwołanie do skryptu Orka
                StartCoroutine(AttackPerSeconds(SO));
                attack = true;
                AnimacjaWojownika.SetBool("attack", attack);
            }
            isColliding = true;
        }
        else if (OrcCollider.gameObject.tag == "TowerEnemy")
        {
            if (!isColliding)
            {
                IsCollidingWithEnemy = true;
                TowerEnemy TE = OrcCollider.gameObject.GetComponent<TowerEnemy>(); // Odwoładnie do skryptu TowerEnemy
                StartCoroutine(AttackTowerPerSeconds(TE));
                attack = true;
                AnimacjaWojownika.SetBool("attack", attack);
            }
            isColliding = true;
        }
    }

    //------------------------------------------------------------------------------------------------- Funkcja wyjścia z kolizji

    void OnTriggerExit2D(Collider2D OrcCollider) // Po wyjściu z kolizji
    {
        
        if (OrcCollider.gameObject.tag == "Enemy" || OrcCollider.gameObject.tag == "TowerEnemy")
            {
            IsCollidingWithEnemy = false;
            DochodziDoKolizji = false;
                attack = false;
                AnimacjaWojownika.SetBool("attack", attack);
                isColliding = false;
            }
    }

    //--------------------------------------------------------------------------------------------------- Funkcja Zadawania Obrażeń

    void DoDmg(SkryptOrk SO)
    {
       SO.HealthOrc -= AttackWarrior;
    }

    //---------------------------------------------------------------------------------------------------- Funkcja atakowania twierdzy
    void AttackTower(TowerEnemy TE)
    {
        TE.EnemyTowerHealth -= AttackWarrior;
    }

    //--------------------------------------------------------------------------------------------------- Obrażenia co 1 sekunde (twierdza)

    IEnumerator AttackTowerPerSeconds(TowerEnemy TE)
    {
        while(valueOfAttacks < 999)
        {
            yield return new WaitForSeconds(1.5f);
            AttackTower(TE);
            valueOfAttacks++;
        }
    }

    //---------------------------------------------------------------------------------------------------- Obrażenia co 1 sekunde (ork)

    IEnumerator AttackPerSeconds(SkryptOrk SO)
    {
        while (valueOfAttacks < 999)
        {
            yield return new WaitForSeconds(1.5f);
            DoDmg(SO);
            valueOfAttacks++;
        }
    }
}