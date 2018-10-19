using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	static public GameManager Instancia { get; private set; }

	//STATE MACHINE
	public enum StateMachine { title, gameRun, gameOver };
	public StateMachine state = StateMachine.title;
	public string heroiNome, heroiMaleDefaultName, heroiFemaleDefaultName; 
	public bool heroiIsMale = true, mozaoIsFemale = true, music = true, sound = true, isFirstGameRun = true;

	public GameObject heroiMale, heroiFemale, mozaoMale, mozaoFemale;
	public InputField nameInput;
	public Text MozaoName;

	//Inclui o flowchart do stage que está como prefab para poder setar a variavel do HeroiName
	public Flowchart flowchart;

	private void Awake()
	{
		if (Instancia == null) Instancia = this;
		else Destroy(this);
		DontDestroyOnLoad(this);
	}

	public void Start()
	{
		heroiMaleDefaultName = "Enzo";
		heroiFemaleDefaultName = "Valentina";
		nameInput.text = GameManager.Instancia.heroiMaleDefaultName;
		MozaoName.text = "Juliana";
	}

	void Update ()
	{
		//Instruções e comandos que só podem ocorrer a qualquer momento do jogo
			//Ativa ou desativa músicas e sons a qualquer momento
			if (Input.GetKeyDown(KeyCode.J)) SetMusic();
			if (Input.GetKeyDown(KeyCode.K)) SetSound();

		//Instruções e comandos que só podem ocorrer durante a tela de título
		if (state == StateMachine.title)
		{
			/*
			if (Input.GetKeyDown(KeyCode.Return) || Input.touchCount > 1)
			{
				PlayGame();
			}
			*/

			if (Input.GetKey(KeyCode.Escape)) CloseGame();
		}

		//Instruções e comandos que só podem ocorrer durante o jogo
		if (state == StateMachine.gameRun)
		{
			if (Input.GetKey(KeyCode.Escape)) PlayTitleScreen();
		}

		//Instruções e comandos que só podem ocorrer durante o game over
		if (state == StateMachine.gameOver)
		{
			if (Input.GetKeyDown(KeyCode.Return)) ReturnToCheckPoint();
		}
	}

    public void PlayGame()
    {
		isFirstGameRun = false;
		state = StateMachine.gameRun;
		SceneManager.LoadScene("Char_select");
    }

	public void PlayTitleScreen()
	{
		state = StateMachine.title;
		SceneManager.LoadScene("Title");
	}

	public void GameOver()
	{
		state = StateMachine.gameOver;
	}

	public void ReturnToCheckPoint()
	{
		//TODO
	}

	public void SetMusic()
	{
		if (music == false) music = true;
		else music = false;
		Debug.Log("Música: " + music);
	}

	public void SetSound()
	{
		if (sound == false) sound = true;
		else sound = false;
		Debug.Log("Sons: " + sound);
	}

	public void CloseGame()
	{
		Application.Quit();
	}

    public void SetNameToFlowChart()
    {
        flowchart.SetStringVariable("HeroiName", heroiNome);
    }

    public void SetMozaoNameToFlowChart(string mozaoName)
    {
        flowchart.SetStringVariable("MozaoName", mozaoName);
    }

    public void SetSexHeroiToFlowChart()
    {
        flowchart.SetBooleanVariable("HeroIsMale", heroiIsMale);
    }

    public void SetSexMozaoToFlowChart()
    {
        flowchart.SetBooleanVariable("MozaoIsFemale", mozaoIsFemale);
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
		GameManager.Instancia.SetNameToFlowChart();
		GameManager.Instancia.SetMozaoNameToFlowChart(MozaoName.text);
		GameManager.Instancia.SetSexHeroiToFlowChart();
		GameManager.Instancia.SetSexMozaoToFlowChart();
		SceneManager.LoadScene("Stage");
	}
}
