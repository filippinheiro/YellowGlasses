using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerenciadorDeUiDeVida : MonoBehaviour {

	private GerenteDeJogo ger;
	private RectTransform rec;
	float widthComum;
	void Start () {
		ger = GameObject.FindGameObjectWithTag("Gerente").GetComponent<GerenteDeJogo>();
		rec = GetComponent<RectTransform>();
		widthComum = rec.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
		rec.sizeDelta = new Vector2(widthComum * ((float)ger.vidaAgora/(float)ger.vidaMax),rec.sizeDelta.y);
	}
}
