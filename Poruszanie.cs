using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poruszanie : MonoBehaviour {

    public float PredkoscPoruszania = 0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PoruszaniePrawo();
	}

    void PoruszaniePrawo()
    {
        if (gameObject.CompareTag("Friend"))
        {
            transform.Translate(Vector2.right * PredkoscPoruszania * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.right * -PredkoscPoruszania * Time.deltaTime);
        }
        //transform.Translate(Vector2.right * PredkoscPoruszania * Time.deltaTime);
    }
}
