using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pontuacao : MonoBehaviour {

	GerenteDeJogo ger;
	Text pontuacaoEscrita;
	void Start () {
		ger = GameObject.FindGameObjectWithTag("Gerente").GetComponent<GerenteDeJogo>();
		pontuacaoEscrita = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		pontuacaoEscrita.text = ger.pontuacao+"pts";
	}
}
