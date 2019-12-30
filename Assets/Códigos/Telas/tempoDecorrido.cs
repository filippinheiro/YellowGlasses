using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempoDecorrido : MonoBehaviour {

	Text tempoEscrito;
	float tempo;
	string minutos, segundos;
	void Start () {
		tempoEscrito = GetComponent<Text>();
		tempo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		tempo += Time.deltaTime;
		tempoEscrito.text = Mathf.Floor((int)tempo/60).ToString("00") + ":" + ((int)tempo%60).ToString("00");
	}
}
