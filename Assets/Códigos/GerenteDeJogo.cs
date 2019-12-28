using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenteDeJogo : MonoBehaviour {
	
	private bool jogoChamado = false;
	public bool JogoIniciado = false;
	private GameObject temp;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(jogoChamado && !JogoIniciado){
			IniciarJogo(temp);
		}
	}

	public void sair(){
		Application.Quit();
	}	

	public void IniciarJogo(GameObject QuemChamou){
		temp = !jogoChamado ? QuemChamou : temp;
		if(!checarAnimacao(QuemChamou)){
			JogoIniciado = true;
		}
		jogoChamado = true;
	}

	private bool checarAnimacao(GameObject Objeto){
		Animation anim = Objeto.GetComponent<Animation>();
		if(anim.name == "Parada")
		return false;
		else
		return true;
	}

}
