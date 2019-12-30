using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirar_Canhao : MonoBehaviour {

	private pooler poolerDeTiros;

	void Start () {
		poolerDeTiros = GameObject.FindGameObjectWithTag("bagTiros").GetComponent<pooler>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			poolerDeTiros.pegarObjeto(0, transform.GetChild(0).position, transform.rotation).GetComponent<tiro_defaut>().ObjetoChamado();
		}
	}
}
