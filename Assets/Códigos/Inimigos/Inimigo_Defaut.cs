using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Defaut : MonoBehaviour {

	public float velocidade;
	public int vidaMax, vidaAgora;
	public Animator anim;
	void Start() {
		anim = GetComponent<Animator>();
	}
	
	public void Up() {
		if(vidaAgora <= 0){
			/*Tem que acertar a animação*/
			gameObject.SetActive(false);
		}	
	}

	public void chamarInimigo(){
		vidaAgora = vidaMax;
		/*Resolver animação*/
	}
}
