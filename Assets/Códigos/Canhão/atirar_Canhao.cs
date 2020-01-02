using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirar_Canhao : MonoBehaviour {

	private pooler poolerDeTiros;
	public float tempoDeTiro;
	float contador;
	Animator anim;
	void Start () {
		poolerDeTiros = GameObject.FindGameObjectWithTag("bagTiros").GetComponent<pooler>();
		contador = 0;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		contador += Time.deltaTime;
		if(Input.GetMouseButtonDown(0) && contador >= tempoDeTiro && Time.timeScale != 0){
			poolerDeTiros.pegarObjeto(0, transform.GetChild(0).position, transform.rotation).GetComponent<tiro_defaut>().ObjetoChamado();
			contador = 0;
		}
	}
}
