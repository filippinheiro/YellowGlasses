using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirar_Canhao : MonoBehaviour {

	private pooler poolerDeTiros, poolerDeEfeitos;
	public float tempoDeTiro, contador;
	Animator anim;
	GerenteDeJogo ger;
	void Start () {
		poolerDeTiros = GameObject.FindGameObjectWithTag("bagTiros").GetComponent<pooler>();
		poolerDeEfeitos = GameObject.FindGameObjectWithTag("bagEfeitos").GetComponent<pooler>();
		contador = 0;
		anim = GetComponent<Animator>();
		ger = GameObject.FindGameObjectWithTag("Gerente").GetComponent<GerenteDeJogo>();
	}
	
	// Update is called once per frame
	void Update () {
		contador += Time.deltaTime;
		if(Input.GetMouseButtonDown(0) && contador >= tempoDeTiro && !ger.jogoPausado){
			poolerDeTiros.pegarObjeto(0, transform.GetChild(0).position, transform.rotation).GetComponent<tiro_defaut>().ObjetoChamado();
			poolerDeEfeitos.pegarObjeto(2, transform.GetChild(0).position, transform.rotation);
			contador = 0;
		}
	}
}
