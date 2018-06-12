using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptOrk : MonoBehaviour
{
    public bool DochodziDoKolizji; // Zmiana animacji z walki na chodzenie
    public Animator AnimacjaOrka; // Animacja chodzenia

    private bool attack; // Zmienna odpowiedzialna za animacje
    private bool isColliding = false; // Zmienna odpowiedzialna za kolizje
    public bool IsCollidingWithFriend = false;

    public float HealthOrc = 100;
    public float AttackOrc = 50;

    private int valueOfAttacks = 0;
    
    //--------------------------------------------------------------------------------------------------- Funkcja Startowa
    void Start()
    {
        AnimacjaOrka = GetComponent<Animator>();
    }

    //--------------------------------------------------------------------------------------------------- Funkcja odświeżania

    void Update()
    {
        if(HealthOrc <= 0)
        {
            WyswietlanieZlota WZ = GameObject.FindObjectOfType<WyswietlanieZlota>(); // Odwołuje się do skryptu WyswietlanieZlota
            Destroy(gameObject);
            WZ.gold += 75;
        }
    }

    //--------------------------------------------------------------------------------------------------- Funkcja gdy dochodzi do kolizji
    void OnTriggerEnter2D(Collider2D WarriorCollider) // Gdy dochodzi do kolizji z Wojownikiem
    {
        if (WarriorCollider.gameObject.tag == "Friend")
        {
            if (!isColliding)
            {
                IsCollidingWithFriend = true;
                SkryptWojownik SW = WarriorCollider.gameObject.GetComponent<SkryptWojownik>(); // Odwołanie do skryptu Wojownika
                StartCoroutine(AttackPerSeconds(SW));
                attack = true;
                AnimacjaOrka.SetBool("attack", attack);
            }
            isColliding = true;
        }

        else if (WarriorCollider.gameObject.tag == "TowerFriend")
        {
            if (!isColliding)
            {
                IsCollidingWithFriend = true;
                TowerFriend TF = WarriorCollider.gameObject.GetComponent<TowerFriend>(); // Odwoładnie do skryptu TowerFriend
                StartCoroutine(AttackTowerPerSeconds(TF));
                attack = true;
                AnimacjaOrka.SetBool("attack", attack);
            }
            isColliding = true;
        }
    }

    //--------------------------------------------------------------------------------------------------- Funkcja wyjścia z kolizji

    void OnTriggerExit2D(Collider2D WarriorCollider) // Po wyjściu z kolizji
    {
        IsCollidingWithFriend = false;
        if (WarriorCollider.gameObject.tag == "Friend" || WarriorCollider.gameObject.tag == "TowerFriend")
        {
            //Debug.Log("triggerexit" + WarriorCollider.gameObject.name);
            DochodziDoKolizji = false;
            attack = false;
            AnimacjaOrka.SetBool("attack", attack);
            isColliding = false;
        }
    }

    //--------------------------------------------------------------------------------------------------- Funkcja Zadawania Obrażeń

    void DoDmg(SkryptWojownik SW)
    {
        SW.HealthWarrior -= AttackOrc;
    }

    //--------------------------------------------------------------------------------------------------- Funkcja atakowania twierdzy
    void AttackTower(TowerFriend TF)
    {
        TF.FriendTowerHealth -= AttackOrc;
    }

    //--------------------------------------------------------------------------------------------------- Obrażenia co 1.5 sekundy (twierdza)
    IEnumerator AttackTowerPerSeconds(TowerFriend TF)
    {
        while (valueOfAttacks < 999)
        {
            yield return new WaitForSeconds(1.5f);
            AttackTower(TF);
            valueOfAttacks++;
        }
    }

    //---------------------------------------------------------------------------------------------------- Obrażenia co 1.5 sekundy (ork)

    IEnumerator AttackPerSeconds(SkryptWojownik SW)
    {
        while (valueOfAttacks < 999)
        {
            yield return new WaitForSeconds(1.5f);
            DoDmg(SW);
            valueOfAttacks++;
        }
    }
}

