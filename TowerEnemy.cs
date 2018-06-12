using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : MonoBehaviour {

    public UnityEngine.UI.Text Zycie_TowerEnemy;

    public float EnemyTowerHealth = 1000;
    public int Nr_Sceny;


    void Start()
    {

    }

    void Update()
    {
        Zycie_TowerEnemy.text = "" + EnemyTowerHealth.ToString("F0");
        if (EnemyTowerHealth <= 0)
        {
            Destroy(gameObject);
            LadujScene();
        }
    }

    void LadujScene()
    {
        Application.LoadLevel(Nr_Sceny);
    }
}
