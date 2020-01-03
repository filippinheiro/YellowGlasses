using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerenciadorDeTiros : MonoBehaviour {

	public atirar_Canhao cann;
	private RectTransform rec;
	public Image cores;
	float widthComum;
	private Color corUsada, corPadrao;
	void Start () {
		rec = GetComponent<RectTransform>();
		widthComum = rec.sizeDelta.x;
		corPadrao = new Color32((byte)(cores.color.r * 255), (byte)(cores.color.g * 255), (byte)(cores.color.b * 255), 255);
	}
	
	// Update is called once per frame
	void Update () {
		rec.sizeDelta = new Vector2(widthComum * (cann.contador/cann.tempoDeTiro),rec.sizeDelta.y);
		corUsada = new Color32(225,144,0,255);
		if(cann.contador/cann.tempoDeTiro < 1){
			cores.color = corUsada;
		}else{
			cores.color = corPadrao;
		}
	}
}
