using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenteDeJogo : MonoBehaviour {
	
	private bool jogoChamado = false;
	public bool JogoIniciado = false;
	private GameObject temp;
	public int vidaMax, vidaAgora; 

	public GameObject [] Spawners;
	public float tempoDeSpawn;
	float contador = 0;
	pooler pool;

	public int pontuacao = 0;

	void Start () {
		vidaAgora = vidaMax;
		pool = GameObject.FindGameObjectWithTag("bagInimigos").GetComponent<pooler>();
	}
	
	// Update is called once per frame
	void Update () {
		if(jogoChamado && !JogoIniciado){
			IniciarJogo(temp);
		}
		if(JogoIniciado){
			mecanicasDeJogo();
		}
	}

	
	void mecanicasDeJogo(){
		contador += Time.deltaTime;
		if(contador >= tempoDeSpawn){
			pool.pegarObjeto(0,Spawners[Mathf.CeilToInt(Random.Range(-1f,2f))].transform.position, new Quaternion(0,0,0,0)).GetComponent<Inimigo_Defaut>().chamarInimigo();
			contador = 0;
		}
	}

	public void diminuirVida(int dano){
		vidaAgora -=  dano;
	}
	public void sair(){
		Application.Quit();
	}	

	public void IniciarJogo(GameObject QuemChamou){
		temp = !jogoChamado ? QuemChamou : temp;
		if(!checarAnimacao(QuemChamou)){
			JogoIniciado = true;
		}
		jogoChamado = true;
	}

	private bool checarAnimacao(GameObject Objeto){
		Animation anim = Objeto.GetComponent<Animation>();
		if(anim.name == "Parada")
		return false;
		else
		return true;
	}

}
