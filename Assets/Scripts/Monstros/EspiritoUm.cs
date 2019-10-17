using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspiritoUm : MonoBehaviour {
	
	public bool esquerda = false;
	public float espiritoUmVel = 2f;
	public Vector2 aPosition1;

	private GameObject lifeManager;
	public SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		lifeManager = GameObject.Find ("LifeManager");
		if (transform.position.x <= 0) {
			esquerda = true;
			aPosition1 = new Vector2 (transform.position.x + 20, transform.position.y);

		} else {
			aPosition1 = new Vector2 (transform.position.x - 20, transform.position.y);
			Vector2 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void Update () {		
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), aPosition1, espiritoUmVel * Time.deltaTime);

		if (esquerda == true && transform.position.x >= 10) {
			lifeManager.GetComponent<LifeManager>().life -= 15;
			Destroy(gameObject);
		}

		if (esquerda == false && transform.position.x <= -10) {
			lifeManager.GetComponent<LifeManager>().life -= 15;
			Destroy(gameObject);
		}
	}
}
