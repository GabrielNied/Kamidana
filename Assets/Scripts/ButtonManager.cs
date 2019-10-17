using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public bool palmaOn = false;
	public bool sinoOn = false;
	private bool lanternaOn = false;
	public bool oferendaOn = false;

	public float tempoCaveira = 0, tempoKappa = 0;

	public EventManager eventManager;
	public LifeManager lifeManager;
	public TempleManager templeManager;

	void Start () {
		
	}

	void Update () {
		if (palmaOn == true) {
			eventManager.spawnadoEspirito1.GetComponent<EspiritoUm> ().spriteRenderer.color -= new Color (255, 255, 255, Time.deltaTime);

			if (eventManager.spawnadoEspirito1.GetComponent<EspiritoUm> ().spriteRenderer.color.a <= (0.0f)) {
				palmaOn = false;
				Destroy (eventManager.spawnadoEspirito1);
			}
		}

		if (sinoOn == true) {
			StartCoroutine ("DestroyCaveira");
		}

		if (oferendaOn == true) {
			eventManager.spawnadoKappa.GetComponent<Kappa> ().spriteRenderer.color -= new Color (255, 255, 255, Time.deltaTime);

			if (eventManager.spawnadoKappa.GetComponent<Kappa> ().spriteRenderer.color.a <= (0.0f)) {
				oferendaOn = false;
				Destroy (eventManager.spawnadoKappa);
			}
		}
	}

	void DestroyCaveira(){

		tempoCaveira += Time.deltaTime;

		if (tempoCaveira >= 4) {
			eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira>().spriteRenderer.color -= new Color(255, 255, 255, Time.deltaTime);
			eventManager.spawnadoCaveira1.GetComponent<Caveira>().spriteRenderer.color -= new Color(255, 255, 255, Time.deltaTime);

			if (eventManager.spawnadoCaveiraMao1.GetComponent<MaoCaveira>().spriteRenderer.color.a <= (0.0f)){

				if (templeManager.amaldicoadoVela == true) {
					templeManager.velaOn = false;
					templeManager.amaldicoadoVela = false;
					templeManager.vela.gameObject.GetComponent<Button> ().interactable = true;
				}
				if (templeManager.amaldicoadoIncenso == true) {
					templeManager.incensoOn = false;
					templeManager.amaldicoadoIncenso = false;
					templeManager.incenso.gameObject.GetComponent<Button> ().interactable = true;
					templeManager.incenso.GetComponent<Image> ().sprite = templeManager.incenso2;
				}
				if (templeManager.amaldicoadoJardim == true) {
					templeManager.jardimOn = false;
					templeManager.amaldicoadoJardim = false;
					templeManager.jardim.gameObject.GetComponent<Button> ().interactable = true;
					templeManager.incenso.GetComponent<Image> ().sprite = templeManager.jardim2;
				}
				if (templeManager.amaldicoadoMeditacao == true) {
					templeManager.meditacaoOn = false;
					templeManager.amaldicoadoMeditacao = false;
					templeManager.meditacao.gameObject.GetComponent<Button> ().interactable = true;
					templeManager.incenso.GetComponent<Image> ().sprite = templeManager.meditacao2;
				}

				sinoOn = false;
				tempoCaveira = 0;
				Destroy(eventManager.spawnadoCaveira1);
				Destroy(eventManager.spawnadoCaveiraMao1);
			}
		}

	}

	public void PalmaClick(){
		if (eventManager.spawnadoEspirito1.active == true) {
			palmaOn = true;
			lifeManager.life += 15;
		}
	}

	public void SinoClick(){
		if (eventManager.spawnadoCaveiraMao1.active == true) {
			sinoOn = true;
			int random = Random.Range (-2, 3);
			tempoCaveira = random;
		}
	}

	public void LanternaClick(){
		lanternaOn = true;
		if (eventManager.spawnadoCao)
			eventManager.espantouCao = true;
	}

	public void OferendaClick(){
		if (eventManager.nasceuKappa == true){
			if (eventManager.spawnadoKappa.GetComponent<Kappa> ().kappaChegou == false) {
				oferendaOn = true;
				eventManager.nasceuKappa = false;
			}
		}
	}

}
