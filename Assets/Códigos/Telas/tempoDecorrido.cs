using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempoDecorrido : MonoBehaviour {

	Text tempoEscrito;
	float tempo;
	private GerenteDeJogo ger;
	public string minutos, segundos;
	
	void Start () {
		tempoEscrito = GetComponent<Text>();
		tempo = 0;
		ger = GameObject.FindGameObjectWithTag("Gerente").GetComponent<GerenteDeJogo>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!ger.jogoPausado){
		tempo += Time.deltaTime;
		minutos = Mathf.Floor((int)tempo/60).ToString("00");
		segundos = ((int)tempo%60).ToString("00");
		tempoEscrito.text = minutos + ":" + segundos;
		}
	}

	public void zerarTempo(){
		tempo = 0;
	}
	
}
