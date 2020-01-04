using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class sounds : MonoBehaviour {

	public GerenteDeJogo ger;
	public bool isSfx;
	Toggle tog;
	void Start () {
		tog = GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
		tog.isOn = isSfx ? ger.sfxMutado : ger.musicMutado;	
	}
}
