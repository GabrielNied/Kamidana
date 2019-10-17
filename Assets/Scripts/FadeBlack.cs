using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour {
	public SpriteRenderer spriteRenderer;
	public bool fadeIn, fadeOut = false;
	public int howLong;
	public GameObject bm;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color (255, 255, 255, 0);
		fadeIn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeIn) FadeIn (); 
		if (fadeOut) FadeOut ();
	}

	void FadeIn() {
		spriteRenderer.color += new Color (255, 255, 255, Time.deltaTime / 3);

		if (spriteRenderer.color.a >= (1)) {
			fadeIn = false;
			StartCoroutine ("WaitFade");
		}
	}

	IEnumerator WaitFade (){
		yield return new WaitForSeconds(howLong);
		bm.GetComponent<ButtonManager> ().oferendaOn = true;
		fadeOut = true;
	}

	void FadeOut(){
		spriteRenderer.color -= new Color (255, 255, 255, Time.deltaTime / 3);

		if (spriteRenderer.color.a <= (0)) {
			gameObject.active = false;
			fadeIn = true;
			fadeOut = false;
		}
	}
}
