using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempleManager : MonoBehaviour {

	public bool velaOn = false;
	public bool incensoOn = false;
	public bool meditacaoOn = false;
	public bool jardimOn = false;

	public bool escolhaKappa = false, influenciaKappa = false;
	public bool amaldicoadoVela = false, amaldicoadoIncenso = false, amaldicoadoJardim = false, amaldicoadoMeditacao = false;
	public bool trancaVela = false, trancaIncenso = false, trancaJardim = false, trancaMeditacao = false;

	public float tempoVela = 0, tempoIncenso = 0;

	public float cdTimer = 0;
	public bool cd = false;

	public GameObject meditacao, jardim, vela, incenso, particlesincenso, particlesvela;
	public Sprite meditacao1, meditacao2, jardim1, jardim2, incenso1, incenso2; 

	public EventManager eventManager;

	void Start () {
		
	}

	void Update () {
		if (cd == true && cdTimer < 3) {
			cdTimer += Time.deltaTime;
		}

		if (cd == true && cdTimer >= 3) {
			meditacao.GetComponent<Button> ().image.color = new Color (255, 255, 255, 1);
			jardim.GetComponent<Button> ().image.color = new Color (255, 255, 255, 1);
			vela.GetComponent<Button> ().image.color = new Color (255, 255, 255, 1);
			incenso.GetComponent<Button> ().image.color = new Color (255, 255, 255, 1);
			cdTimer = 0;
			cd = false;
		}	
			MaldicaoVela ();
			MaldicaoIncenso ();
			MaldicaoJardim ();
			MaldicaoMeditacao ();
	}

	public void TimeTick (float time) {
		if (amaldicoadoVela == false) {
			if (velaOn == true) {
				tempoVela += time;
			}
			if (velaOn && tempoVela >= 20) {
				particlesvela.gameObject.SetActive (false);
				vela.gameObject.GetComponent<Button> ().interactable = true;
				velaOn = false;
				tempoVela = 0;
			}
		}

		if(amaldicoadoIncenso == false){
			if (incensoOn == true) {
				tempoIncenso += time;
				if (tempoIncenso >= 1) {
					int choice = Random.Range (0, 10);
					switch (choice) {
					case 9:
						particlesincenso.gameObject.SetActive (false);
						incenso.gameObject.GetComponent<Button> ().interactable = true;
						incensoOn = false;
						incenso.GetComponent<Image> ().sprite = incenso2;

						break;
					}
					tempoIncenso = 0;
				}
			}
		}


		if (eventManager.spawnadoKappa) {
			//Debug.Log ("SpawnouKappa");
			if (eventManager.spawnadoKappa.GetComponent<Kappa> ().kappaChegou == true) {
				// TODO Adicionar modificador aleatoŕio
				influenciaKappa = true;
			} else {
				influenciaKappa = false;
			}
		}

	}

	public void CoolDown(){
		meditacao.GetComponent<Button>().image.color -= new Color(1,1,1, 0.75f);
		jardim.GetComponent<Button>().image.color -= new Color(1,1,1, 0.75f);
		vela.GetComponent<Button>().image.color -= new Color(1,1,1, 0.75f);
		incenso.GetComponent<Button>().image.color -= new Color(1,1,1, 0.75f);
	}

	public void VelaClick(){
		if (amaldicoadoVela == true) {
				
			} else {
				if (velaOn == false) {
					if (cd == false) {
						particlesvela.gameObject.SetActive (true);
						vela.gameObject.GetComponent<Button> ().interactable = false;
						velaOn = true;
					//Debug.Log ("vela2: "+velaOn);
						meditacao.GetComponent<Image> ().sprite = meditacao1;
						meditacaoOn = false;
						CoolDown ();
						cd = true;
					}
				}
			}
		}


	public void IncensoClick(){
		if (amaldicoadoIncenso == true) {
				
			} else {
				if (incensoOn == false) {
					if (cd == false) {
						particlesincenso.gameObject.SetActive (true);
						incenso.gameObject.GetComponent<Button> ().interactable = false;
						incenso.GetComponent<Image> ().sprite = incenso1;
						incensoOn = true;
					//Debug.Log ("incensoOn2: "+incensoOn);
						meditacao.GetComponent<Image> ().sprite = meditacao1;
						meditacaoOn = false;
						CoolDown ();
						cd = true;
					}
				}
			}
		}

	public void MeditacaoClick(){
		if (amaldicoadoMeditacao == true) {
				
			} else {
				if (cd == false) {
					if (meditacaoOn == false) {
						meditacao.GetComponent<Image> ().sprite = meditacao2;
						meditacaoOn = true;
						CoolDown ();
						cd = true;
					} else {
						meditacao.GetComponent<Image> ().sprite = meditacao1;
						meditacaoOn = false;
					}
				}
			}
		}


	public void JardimClick(){
		if (amaldicoadoJardim == true) {

			} else {
				if (cd == false) {
					if (jardimOn == false) {
						jardim.GetComponent<Image> ().sprite = jardim2;
						jardimOn = true;
						meditacao.GetComponent<Image> ().sprite = meditacao1;
						meditacaoOn = false;
						CoolDown ();
						cd = true;
					} else {
						jardim.GetComponent<Image> ().sprite = jardim1;
						jardimOn = false;
						meditacao.GetComponent<Image> ().sprite = meditacao1;
						meditacaoOn = false;
						CoolDown ();
						cd = true;
					}
				}
			}
		}

	public void MaldicaoVela(){
		if (eventManager.spawnadoCaveiraMao1) {
			if (eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().caso2 == true && eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().chegou == true) {
				if (velaOn) {
					vela.gameObject.GetComponent<Button> ().interactable = false;
					particlesvela.gameObject.SetActive (false);
					velaOn = true;
					//Debug.Log ("vela3: "+velaOn);
					amaldicoadoVela = true;
				} else {
					vela.gameObject.GetComponent<Button> ().interactable = false;
					particlesvela.gameObject.SetActive (true);
					velaOn = true;
					//Debug.Log ("vela4: "+velaOn);
					amaldicoadoVela = true;
				}
			}
		}
	}

	public void MaldicaoIncenso(){
		if (eventManager.spawnadoCaveiraMao1) {
			if (eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().caso3 == true && eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().chegou == true) {
				if (incensoOn == true) {
					incenso.gameObject.GetComponent<Button> ().interactable = false;
					particlesincenso.gameObject.SetActive (false);
					incensoOn = true;
					incenso.GetComponent<Image> ().sprite = incenso1;
					//Debug.Log ("incensoOn3: "+incensoOn);
					amaldicoadoIncenso = true;
				} else {
					incenso.gameObject.GetComponent<Button> ().interactable = false;
					particlesincenso.gameObject.SetActive (true);
					incensoOn = true;
					incenso.GetComponent<Image> ().sprite = incenso1;
					//Debug.Log ("incensoOn4: "+incensoOn);
					amaldicoadoIncenso = true;
				}
			}
		}
	}

	public void MaldicaoJardim(){
		if (eventManager.spawnadoCaveiraMao1) {
			if (eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().caso1 == true && eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().chegou == true) {
				jardim.gameObject.GetComponent<Button> ().interactable = false;
				jardimOn = true;
				amaldicoadoJardim = true;
			}
		}
	}

	public void MaldicaoMeditacao(){
		if (eventManager.spawnadoCaveiraMao1) {
			if (eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().caso4 == true && eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira> ().chegou == true) {
				meditacao.gameObject.GetComponent<Button> ().interactable = false;
				meditacaoOn = true;
				amaldicoadoMeditacao = true;
			}
		}
	}

	public int GetTempleBalance(){
		int sum = 0;

		if (velaOn) {
			if (amaldicoadoVela == true) {
				sum += 2;

			} else {
				sum -= 1;
			}
		}

		if (meditacaoOn) {
			if (amaldicoadoMeditacao == true) {
				sum -= 4;

			} else {
				sum += 2;
			}
		}

		if (incensoOn) {
			if (amaldicoadoIncenso == true) {
				sum += 2;

			} else {
				sum -= 1;
			}
		}

		if (jardimOn) {
			if (amaldicoadoJardim == true) {
				sum -= 2;

			} else {
				sum += 1;
			}
		}

		if (influenciaKappa) {
			int mod = Random.Range (4, 10);
			switch (Random.Range (0, 2)) {
			case 0:
				sum += mod;
				break;
			case 1:
				sum -= mod;
				break;
			}
		}

		//Debug.Log ("Sum: "+sum);
		return sum;
	}
}


