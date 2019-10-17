using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveira : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public bool fade = false;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color (255, 255, 255, 0);
	}

	void Update(){
		if (fade == false) {
			FadeIn ();
		}
	}

	public void FadeIn(){
		spriteRenderer.color += new Color (255, 255, 255, Time.deltaTime/3);

		if (spriteRenderer.color.a >= (1)) {
			fade = true;
	}
}
}