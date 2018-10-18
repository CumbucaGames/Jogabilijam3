using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	static public GameManager Instancia { get; private set; }

	//STATE MACHINE
	public enum StateMachine { title, gameRun, gameOver };
	public StateMachine state = StateMachine.title;
	public string heroiNome, heroiMaleDefaultName, heroiFemaleDefaultName; 
	public bool heroiIsMale = true, mozaoIsFemale = true, music = true, sound = true, isFirstGameRun = true;

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
}
