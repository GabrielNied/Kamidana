using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public TempleManager templeManager;
	public LifeManager lifeManager;
	public Text vidaText;


	public float tempoVela = 0;
	public float tempoMeditacao = 0;
	public float tempoJardim = 0;
	public float tempoIncenso = 0;


	public float gameTime = 0;
	private float timeSpent = 0;
	public float timeFrame = 2;

	public bool vidaInicio = false;
	public int multiplier = 1;

	void Start () {
		int choice = Random.Range(0, 2);
		switch (choice)
		{
		case 0:
			vidaInicio = true;
			break;
		case 1:
			vidaInicio = false;
			break;
		}
	}

	void Update () {
		gameTime += Time.deltaTime;

		if (gameTime >= timeFrame) {
			Debug.Log ("Step Start");
			if (gameTime > 20 && gameTime <= 40) {
				multiplier = 2;
			} else if (gameTime > 40 && gameTime >= 60) {
				multiplier = 4;
			} else if (gameTime > 60 && gameTime >= 80) {
				multiplier = 6;
			}


			if (vidaInicio == true) {
				lifeManager.life -= Random.Range (1, multiplier);
			} else {
				lifeManager.life += Random.Range(1, multiplier);
			}

			if (lifeManager.life <= 0) {

			}
			if (lifeManager.life >= 100) {

			}
			//Debug.Log ("Chamouasdasd: " + timeFrame);
			templeManager.TimeTick (timeFrame);
			lifeManager.AddBalance (templeManager.GetTempleBalance ());

			//vidaText.text = ("Vida: " + lifeManager.life.ToString("f0"));

			gameTime = 0;

			Debug.Log ("Step End");
		}
	}
}
