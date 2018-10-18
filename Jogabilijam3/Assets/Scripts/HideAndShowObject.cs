using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndShowObject : MonoBehaviour {

	void Awake ()
	{
		if (!GameManager.Instancia.isFirstGameRun) gameObject.SetActive(true);
	}
}
