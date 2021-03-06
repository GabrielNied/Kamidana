﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaoCaveira : MonoBehaviour {

	public Vector2 posicaoMaoFinal;
	public int velMao = 1;
	public bool fade = false;
	public bool caso1 = false, caso2 = false, caso3 = false, caso4 = false, chegou = false;
	public float tempoParado = 0;
	public SpriteRenderer spriteRenderer;
	public GameObject templeManager, gameManager;

	public float comecarMovimentacao = 0;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		templeManager = GameObject.Find ("TempleManager");
		gameManager = GameObject.Find ("GameManager");
		spriteRenderer.color = new Color (255, 255, 255, 0);
		EscolheLocal ();
	}

	void Update () {
		comecarMovimentacao += Time.deltaTime;
		if (fade == false) {
			FadeIn ();
		}

		if (comecarMovimentacao >= 3f) {
			Movimentacao ();
		}

		if (caso1 == true && transform.position.x == -5 && transform.position.y == -2.5f) {
			chegou = true;
		}
		if (caso2 == true && transform.position.x == 0 && transform.position.y == -2.5f) {
			chegou = true;
		}
		if (caso3 == true && transform.position.x == 0 && transform.position.y == -0.5f) {
			chegou = true;
		}
		if (caso4 == true && transform.position.x == 5 && transform.position.y == -2.5f) {
			chegou = true;
		}

		if (chegou == true) {
			tempoParado += Time.deltaTime;
			if (tempoParado >= 30) {
				EscolheLocal ();
				if (templeManager.GetComponent<TempleManager> ().amaldicoadoVela == true) {
					templeManager.GetComponent<TempleManager> ().velaOn = false;
					templeManager.GetComponent<TempleManager> ().amaldicoadoVela = false;
					templeManager.GetComponent<TempleManager> ().vela.GetComponent<Button> ().interactable = true;
				}
				if (templeManager.GetComponent<TempleManager> ().amaldicoadoIncenso == true) {
					templeManager.GetComponent<TempleManager> ().incensoOn = false;
					templeManager.GetComponent<TempleManager> ().amaldicoadoIncenso = false;
					templeManager.GetComponent<TempleManager> ().incenso.GetComponent<Button> ().interactable = true;
				}
				if (templeManager.GetComponent<TempleManager> ().amaldicoadoJardim == true) {
					templeManager.GetComponent<TempleManager> ().jardimOn = false;
					templeManager.GetComponent<TempleManager> ().amaldicoadoJardim = false;
					templeManager.GetComponent<TempleManager> ().jardim.GetComponent<Button> ().interactable = true;
				}
				if (templeManager.GetComponent<TempleManager> ().amaldicoadoMeditacao == true) {
					templeManager.GetComponent<TempleManager> ().meditacaoOn = false;
					templeManager.GetComponent<TempleManager> ().amaldicoadoMeditacao = false;
					templeManager.GetComponent<TempleManager> ().meditacao.GetComponent<Button> ().interactable = true;
				}
				tempoParado = 0;
			}
		}
	}

	public void FadeIn(){
		spriteRenderer.color += new Color (255, 255, 255, Time.deltaTime / 3);

		if (spriteRenderer.color.a >= (1)) {
			fade = true;
		}
	}

	public void Movimentacao(){
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), posicaoMaoFinal, velMao * Time.deltaTime * gameManager.GetComponent<GameManager>().multiplier);
	}

	public void EscolheLocal(){
		caso1 = false;
		caso2 = false;
		caso3 = false;
		caso4 = false;
		chegou = false;
		int choice = Random.Range (0, 4);
		switch (choice) {
		case 0: 
			caso1 = true;
			posicaoMaoFinal = new Vector2 (-5, -2.5f);
			break;

		case 1: 
			caso2 = true;
			posicaoMaoFinal = new Vector2 (0, -2.5f);
			break;

		case 2: 
			caso3 = true;
			posicaoMaoFinal = new Vector2 (0, -0.5f);	
			break;

		case 3: 
			caso4 = true;
			posicaoMaoFinal = new Vector2 (5, -2.5f);
			break;
		}
	}
}
