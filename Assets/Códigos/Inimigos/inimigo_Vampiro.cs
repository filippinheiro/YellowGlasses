using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo_Vampiro : Inimigo_Defaut {

	private Rigidbody2D rig;
	private Camera cam;
	private float heightCam;
	private float widthCam;
	private float inimigoSizeX;
	public bool direita;

	void Start () {
		StartThis();
		
		rig = this.GetComponent<Rigidbody2D>();
		
		#region Achando Tamanho da Câmera
		cam = Camera.main;
		heightCam = 2f * cam.orthographicSize;
 		widthCam = heightCam * cam.aspect;
		#endregion

		inimigoSizeX = this.GetComponent<SpriteRenderer>().size.x * transform.localScale.x;
	}
	
	void Update () {
		if((transform.position.x > widthCam/2 - inimigoSizeX/2 && direita) || (transform.position.x < -widthCam/2 + inimigoSizeX/2 && !direita)){
			direita = !direita;
		}
		rig.velocity = direita ? new Vector2(velocidade,-velocidade*0.3f) : new Vector2(-velocidade,-velocidade*0.3f);
		Up();
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		if(coll.tag == "Inimigo"){
			direita = !direita;
		}else
		if(coll.tag == "tiro"){
			vidaAgora--;
		}else
		if(coll.tag == "Cerca"){
			ger.diminuirVida(dano);
			Explodir();
		}
	}

	
}
