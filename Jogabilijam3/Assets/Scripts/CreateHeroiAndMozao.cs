using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeroiAndMozao : MonoBehaviour {

	public GameObject heroi, mozao;
	//public Character heroi, mozao, grupo;

	void Awake ()
	{

		//heroi.GetComponent<Character>().NameText = GameManager.Instancia.heroiNome;
		//mozao.GetComponent<Character>().

		//INSTANCIANDO O HEROI
		if (GameManager.Instancia.heroiIsMale)
		{

		}
		else
		{
			
		}

		//INSTANCIANDO O INTERESSE AMOROSO
		if (GameManager.Instancia.mozaoIsFemale)
		{
			
		}
		else
		{
			
		}

		Destroy(gameObject);
	}
}
