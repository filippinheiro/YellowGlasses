using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempoDecorrido : MonoBehaviour {

	Text tempoEscrito;
	float tempo;
	public string minutos, segundos;
	void Start () {
		tempoEscrito = GetComponent<Text>();
		tempo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		tempo += Time.deltaTime;
		minutos = Mathf.Floor((int)tempo/60).ToString("00");
		segundos = ((int)tempo%60).ToString("00");
		tempoEscrito.text = minutos + ":" + segundos;
	}

	public void zerarTempo(){
		tempo = 0;
	}
}
