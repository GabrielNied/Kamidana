using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public GameObject espirito1, spawnadoEspirito1, caveira1, caveira1Mao, spawnadoCaveira1, spawnadoCaveiraMao1, kappa, spawnadoKappa, eyes, fadeBlack;
	public float tempoSpawnEspirito1 = 0;
	public float tempoSpawnCaveira1 = 0;
	public float tempoChanceCaveira = 0;
	public float tempoSpawnKappa = 0;
	public float tempoSpawnCao = 0, tempoCao = 5, timerCao = 0, tempoEscuro = 2;

	public bool nasceuKappa = false, avisouCao = false, spawnadoCao = false, espantouCao = false;

	Vector2 posicaoCaveira, posicaoMao, posicaoKappa;

	public ButtonManager buttonManager;
	public LifeManager lifeManager;

	public GameObject rain, petals, snow, nevoa;

	public float gameTime = 0;

	void Start () {
		int randomTempoI = Random.Range(0, 5);
		tempoSpawnEspirito1 = randomTempoI;
		posicaoCaveira = new Vector2 (-5.5f, 3.1f);
		posicaoMao = new Vector2 (-5, 0);
		posicaoKappa = new Vector2 (11.5f, -0.8f);
	}

	void Update () {
		tempoSpawnEspirito1 += Time.deltaTime;
		tempoSpawnCaveira1 += Time.deltaTime;
		tempoSpawnKappa += Time.deltaTime;
		gameTime += Time.deltaTime;

		if (tempoSpawnEspirito1 >= 25) {
			float random = Random.Range (4, -2);
			float mouseX = Input.mousePosition.x;
			if (mouseX >= 375) {
				transform.position = new Vector3 (-10, random, 0);
			} else {
				transform.position = new Vector3 (10, random, 0);
			}
			spawnadoEspirito1 = Instantiate (espirito1, transform.position, Quaternion.identity);
			int randomTempo = Random.Range(-5, 0);
			tempoSpawnEspirito1 = randomTempo;
		}
		spawnadoEspirito1 = GameObject.Find ("Espirito(Clone)");


		if (!spawnadoCaveira1) {
		if (tempoSpawnCaveira1 >= 5) {
			tempoChanceCaveira += Time.deltaTime;

				if (tempoChanceCaveira >= 1) {
					int random = Random.Range (0, 10);
					if (random == 9) {
						spawnadoCaveira1 = Instantiate (caveira1, posicaoCaveira, Quaternion.identity);
						spawnadoCaveiraMao1 = Instantiate (caveira1Mao, posicaoMao, Quaternion.identity);
						tempoSpawnCaveira1 = 0;
					}
					tempoChanceCaveira = 0;
				}
			} 
		}else {
			tempoSpawnCaveira1 = 0;
			tempoChanceCaveira = 0;
		}
		spawnadoCaveira1 = GameObject.Find ("Caveira(Clone)");
		spawnadoCaveiraMao1 = GameObject.Find ("Mao(Clone)");


		if (!spawnadoKappa) {
			if (tempoSpawnKappa >= 5) {
				nasceuKappa = true;
				nevoa.gameObject.GetComponent<ParticleSystem> ().Play ();
				if (tempoSpawnKappa >= 10) {				
					spawnadoKappa = Instantiate (kappa, posicaoKappa, Quaternion.identity);
					tempoSpawnKappa = 0;
				}
			} else {
				nevoa.gameObject.GetComponent<ParticleSystem> ().Stop ();
			}
		} else {
			tempoSpawnKappa = 0;
		}
		spawnadoKappa = GameObject.Find ("Kappa(Clone)");


		// CheckWhen
		if (!spawnadoCao) {
			if (tempoSpawnCao >= 10) {;
				//Avisa, glows eyes
				timerCao = tempoCao;
				spawnadoCao = true;
				foreach (ParticleSystem eye in eyes.GetComponentsInChildren<ParticleSystem> ()) {
					eye.Play ();
				}
			} else {
				tempoSpawnCao += Time.deltaTime;
			}
		} else {
			// e não acendeu
			if (timerCao < 0 && !espantouCao) {
				spawnadoCao = false;
				fadeBlack.SetActive (true);

				//Kills spirits
				//resets
				tempoSpawnCao = 0;
				timerCao = tempoCao;
				espantouCao = false;
			} else if (spawnadoCao) {
				timerCao -= Time.fixedDeltaTime;
			}
		}


		//if (!spawnadoOni) {
		//}


		if (gameTime >= 10 && gameTime <= 19) {
			rain.gameObject.SetActive (false);
			petals.gameObject.SetActive (true);
			snow.gameObject.SetActive (false);
		}
		if (gameTime >= 20 && gameTime <= 39) {
			rain.gameObject.SetActive (true);
			petals.gameObject.SetActive (false);
			snow.gameObject.SetActive (false);
		}
		if (gameTime >= 40 && gameTime <= 59) {
			rain.gameObject.SetActive (false);
			petals.gameObject.SetActive (false);
			snow.gameObject.SetActive (true);
		}
	}
}