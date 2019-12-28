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
	
	void Update() {
		if(vidaAgora >= 0){
			/*Tem que acertar a animação*/
			gameObject.SetActive(false);
		}	
	}

	private void OnTriggerEnter2D(Collider2D tiro) {
		if(tiro.tag == "tiro"){
			vidaAgora--;
		}
	}

}
