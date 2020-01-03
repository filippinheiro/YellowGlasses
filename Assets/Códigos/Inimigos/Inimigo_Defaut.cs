using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Defaut : MonoBehaviour {

	public float velocidadeMax, velocidadeMin, velocidade;
	public int vidaMax, vidaAgora;
	public Animator anim;
	public int dano;

	public GerenteDeJogo ger;
	public pooler poolEfeitos;
	public void StartThis() {
		anim = GetComponent<Animator>();
		poolEfeitos = GameObject.FindGameObjectWithTag("bagEfeitos").GetComponent<pooler>();
	}
	
	public void Up() {
		if(vidaAgora <= 0){
			poolEfeitos.pegarObjeto(0, transform.position, transform.rotation);
			ger.pontuacao += dano;
			gameObject.SetActive(false);
		}	
		GetComponent<Rigidbody2D>().simulated = !ger.jogoPausado;
		GetComponent<Animator>().enabled = !ger.jogoPausado;
	}

	public void chamarInimigo(){
		vidaAgora = vidaMax;
		ger = GameObject.FindGameObjectWithTag("Gerente").GetComponent<GerenteDeJogo>();
		velocidade = Random.Range(velocidadeMin + ger.dificuldade,velocidadeMax + ger.dificuldade);
	}

	public void Explodir(){
		poolEfeitos.pegarObjeto(1, transform.position, transform.rotation);
		gameObject.SetActive(false);
	}
}
