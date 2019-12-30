using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Defaut : MonoBehaviour {

	public float velocidade;
	public int vidaMax, vidaAgora;
	public Animator anim;
	public int dano;

	public GerenteDeJogo ger;
	public void StartThis() {
		anim = GetComponent<Animator>();
		ger = GameObject.FindGameObjectWithTag("Gerente").GetComponent<GerenteDeJogo>();
	}
	
	public void Up() {
		if(vidaAgora <= 0){
			/*Tem que acertar a animação*/
			ger.pontuacao += dano;
			gameObject.SetActive(false);
		}	
	}

	public void chamarInimigo(){
		vidaAgora = vidaMax;
		/*Resolver animação*/
	}

	public void Explodir(){
		gameObject.SetActive(false);
		/*Incluir animação de explosão*/
	}
}
