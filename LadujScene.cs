using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadujScene : MonoBehaviour {

	// Use this for initialization
	public void ZaladujScene (int nrSceny) {
        Application.LoadLevel (nrSceny);
	}
	
	// Update is called once per frame
	public void Wyjscie () {
        Application.Quit();
	}
}