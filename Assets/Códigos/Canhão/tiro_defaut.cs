using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro_defaut : MonoBehaviour {
	float heightCam;
	float widthCam;
	Rigidbody2D rig;
	public float velocidade;
	
	void Update() {
		if(transform.position.x > widthCam/2 || transform.position.x < -widthCam/2 || transform.position.y > heightCam/2){
			gameObject.SetActive(false);
		}
	}

	public void ObjetoChamado(){
		#region sabendo o tamanho da tela
		Camera cam = Camera.main;
		heightCam = 2f * cam.orthographicSize;
 		widthCam = heightCam * cam.aspect;
		#endregion
		
		#region setar o lado para onde vai o tiro
		Quaternion frente = transform.rotation;
		float porcentagemX, porcentagemY;
		porcentagemX = -(frente.z/90)*100;
		porcentagemY = Mathf.Abs(Mathf.Abs(porcentagemX) - 1);
		rig = GetComponent<Rigidbody2D>();
		rig.velocity = new Vector2(0,0);
		rig.AddForce(new Vector2(velocidade * 2 * porcentagemX, velocidade* 2 * porcentagemY));
		#endregion

	}

	void OnTriggerEnter2D(Collider2D inimigo) {
		if(inimigo.tag == "Inimigo"){
			gameObject.SetActive(false);
		}
	}
}
