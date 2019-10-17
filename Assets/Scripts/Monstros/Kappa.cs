using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kappa : MonoBehaviour {

	public Vector2 aPosition1;
	public SpriteRenderer spriteRenderer;
	public float kappaVel = 0.5f;
	public GameObject gameManager;

	public bool kappaChegou = false;

	void Start () {
		gameManager = GameObject.Find ("GameManager");
		spriteRenderer = GetComponent<SpriteRenderer>();
		aPosition1 = new Vector2 (6.3f, -0.8f);
	}

	void Update () {
		Movimentacao ();
	}

	public void Movimentacao(){
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), aPosition1, kappaVel * Time.deltaTime/2 * gameManager.GetComponent<GameManager>().multiplier);
		if (transform.position.x == 6.3f && transform.position.y == -0.8f) {
			Debug.Log ("Clock");
			kappaChegou = true;
		}
	}
}
