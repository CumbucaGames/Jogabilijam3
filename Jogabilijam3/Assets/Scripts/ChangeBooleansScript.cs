using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeBooleansScript : MonoBehaviour {

	public GameObject heroiMale, heroiFemale, mozaoMale, mozaoFemale;
	public InputField nameInput;
	public Text MozaoName;

	public void Start()
	{
		nameInput.text = GameManager.Instancia.heroiMaleDefaultName;
		MozaoName.text = "Juliana";
	}

	public void ChangeHeroiName(string newName)
	{
		GameManager.Instancia.heroiNome = newName;
	}

	public void HeroiIsMale()
	{
		GameManager.Instancia.heroiIsMale = true;
		heroiMale.SetActive(true);
		heroiFemale.SetActive(false);
		nameInput.text = GameManager.Instancia.heroiMaleDefaultName;
	}

	public void HeroiIsFemale()
	{
		GameManager.Instancia.heroiIsMale = false;
		heroiMale.SetActive(false);
		heroiFemale.SetActive(true);
		nameInput.text = GameManager.Instancia.heroiFemaleDefaultName;

	}

	public void MozaoIsMale()
	{
		GameManager.Instancia.mozaoIsFemale = false;
		mozaoMale.SetActive(true);
		mozaoFemale.SetActive(false);
		MozaoName.text = "Luiz";
	}

	public void MozaoIsFemale()
	{
		GameManager.Instancia.mozaoIsFemale = true;
		mozaoMale.SetActive(false);
		mozaoFemale.SetActive(true);
		MozaoName.text = "Juliana";
	}

	public void StartStory()
	{
		GameManager.Instancia.heroiNome = nameInput.text;
		GameManager.Instancia.isFirstGameRun = false;
		SceneManager.LoadScene("Stage");
	}

}
