using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFriend : MonoBehaviour {

    public UnityEngine.UI.Text Zycie_TowerFriend;

    public float FriendTowerHealth = 1000;
    public int Nr_Sceny;

    void Start()
    {

    }

    void Update()
    {
        Zycie_TowerFriend.text = "" + FriendTowerHealth.ToString("F0");
        if (FriendTowerHealth <= 0)
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
