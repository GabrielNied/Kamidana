using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

	public float life = 50;
	public Sprite meio, yin1, yin2, yin3, yin4, yang1, yang2, yang3, yang4; // yin preto, yang branco

	public SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {

		if (life >= 95 && life < 100) 	spriteRenderer.sprite = yang4;
		if (life >= 85 && life < 95) 	spriteRenderer.sprite = yang3;
		if (life >= 70 && life < 85) 	spriteRenderer.sprite = yang2;
		if (life >= 52 && life < 70) 	spriteRenderer.sprite = yang1;
		if (life >= 48 && life < 52) 	spriteRenderer.sprite = meio;
		if (life >= 30 && life < 48) 	spriteRenderer.sprite = yin1;
		if (life >= 15 && life < 30) 	spriteRenderer.sprite = yin2;
		if (life >= 5 && life < 15) 	spriteRenderer.sprite = yin3;
		if (life >= 0 && life < 5) 		spriteRenderer.sprite = yin4;
	}

	public void AddBalance (int balance){
		life += balance;
		//Debug.Log ("Vida: " + life);
		//Debug.Log ("balance: " + balance);
	}
}
