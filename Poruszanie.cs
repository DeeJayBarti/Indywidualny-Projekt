using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poruszanie : MonoBehaviour {

    public float MovementSpeed = 0.5f;

    void Start ()
    {
        /*if(gameObject.tag == "Enemy")
        {
            GetComponent<SkryptOrk>
        }
        else if(gameObject.tag == "Friend")
        {
            GetComponent<SkryptWojownik>
        }*/
		//if tag enemy to bierzemy getckomponent ork jak drugi tag to wojownik
	}
	

	void Update () {
        PoruszaniePrawo();
	}

    void PoruszaniePrawo()
    {
        SkryptWojownik SW = GameObject.FindObjectOfType<SkryptWojownik>();
        SkryptOrk SO = GameObject.FindObjectOfType<SkryptOrk>();
        if (gameObject.CompareTag("Friend"))
        {
            if(!SW.IsCollidingWithEnemy)
                transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            if(!SO.IsCollidingWithFriend)
                transform.Translate(Vector2.right * -MovementSpeed * Time.deltaTime);
        }
    }
}
