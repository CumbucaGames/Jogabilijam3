using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookToMouse : MonoBehaviour {

	public Vector3 MousePositionX;
	public float ScreenCenter; 
	SpriteRenderer papagaio;

	private void Start()
	{
		papagaio = gameObject.GetComponent<SpriteRenderer>();
		ScreenCenter = Screen.width / 2;
	}
	void Update ()
	{
		MousePositionX = Input.mousePosition;
		if (MousePositionX.x < ScreenCenter)
		{
			FlipSprite();
		}
		else
		{
			UnflipSprite();
		}

	}

	void FlipSprite()
	{
		papagaio.flipX = true;
	}

	void UnflipSprite()
	{
		papagaio.flipX = false;
	}
}
