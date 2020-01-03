using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenteDeJogo : MonoBehaviour {
	
	public bool jogoPausado = false;
	public float dificuldade = 0;
	public bool JogoIniciado = false;
	private GameObject temp;
	public int vidaMax, vidaAgora; 

	public GameObject [] Spawners;
	public float tempoDeSpawn;
	public float contador = 0;
	pooler pool;

	public int pontuacao = 0;

	public GameObject initScreen;
	public GameObject gameScreen;
	public GameObject pauseScreen;
	public GameObject endScreen;
	public Text pontuacaoTxt, recordTxt, pontFinal;
	public pontuacao pont;
	public tempoDecorrido tempoDec;

	void Start () {
		vidaAgora = vidaMax;
		pool = GameObject.FindGameObjectWithTag("bagInimigos").GetComponent<pooler>();
	}
	
	// Update is called once per frame
	void Update () {
		if(JogoIniciado && !jogoPausado){
			mecanicasDeJogo();
			tenteMorrer();
		}
	}

	
	void mecanicasDeJogo(){
		dificuldade += dificuldade < 3 ? Time.deltaTime/60f : 0;
		contador += Time.deltaTime;
		if(contador + dificuldade/2 >= tempoDeSpawn){
			int quantosInimPSpawn = Mathf.CeilToInt(Random.Range(dificuldade,3f));
			int [] locais = new int[quantosInimPSpawn];
			int i = 0;
			while(i<quantosInimPSpawn){
				locais[i] = Mathf.CeilToInt(Random.Range(-1f,2f));
				for(int j = 0; j<quantosInimPSpawn;j++){
					if(locais[i] == locais[j] && j != i){
							while(locais[i] == locais[j]){
								locais[i] = Mathf.CeilToInt(Random.Range(-1f,2f));
							}
					}
					
				}	
				GameObject temporario = pool.pegarObjeto(0,Spawners[locais[i]].transform.position, new Quaternion(0,0,0,0));
				temporario.GetComponent<Inimigo_Defaut>().chamarInimigo();
				i++;
			}
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
			QuemChamou.GetComponent<Animator>().SetTrigger("Saia");			
			vidaAgora = vidaMax;
			JogoIniciado = true;
			jogoPausado = false;
			gameScreen.SetActive(true);
			gameScreen.GetComponent<Animator>().SetTrigger("Volte");
			pontuacao = 0;
			dificuldade = 0;
			tempoDec.zerarTempo();
	}

	public void pausarJogo(){
		pauseScreen.SetActive(true);
		jogoPausado = true;
	}

	public void despausar(){
		Time.timeScale = 1;
		jogoPausado = false;
		gameScreen.SetActive(true); 
	}

	public void menuPrincipal(){
		Time.timeScale = 1;
		JogoIniciado = false;
		initScreen.SetActive(true);
		GameObject [] inimigos;
		inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
		for(int i = 0; i<inimigos.Length;i++){
			inimigos[i].GetComponent<Inimigo_Defaut>().Explodir();
		}
	}

	private void tenteMorrer(){
		if(vidaAgora <= 0 && JogoIniciado){
			GameObject [] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
			for(int i = 0; i<inimigos.Length;i++){
				inimigos[i].GetComponent<Inimigo_Defaut>().Explodir();
			}
			
			gameScreen.GetComponent<Animator>().SetTrigger("Saia");	
			endScreen.SetActive(true);
			endScreen.GetComponent<Animator>().SetTrigger("Volte");
			pontuacaoTxt.text = tempoDec.minutos + "min x " +tempoDec.segundos + "sec = " + int.Parse(tempoDec.minutos) * int.Parse(tempoDec.segundos)+"\n+"+pontuacao+"pts";
			pontFinal.text = (int.Parse(tempoDec.minutos) * int.Parse(tempoDec.segundos) + pontuacao)+"pts";
			if(PlayerPrefs.GetInt("recorde") == 0 || int.Parse(tempoDec.minutos) * int.Parse(tempoDec.segundos) + pontuacao > PlayerPrefs.GetInt("recorde") || PlayerPrefs.GetInt("recorde") == null){
				PlayerPrefs.SetInt("recorde", int.Parse(tempoDec.minutos) * int.Parse(tempoDec.minutos) + pontuacao);
				recordTxt.text = (int.Parse(tempoDec.minutos) * int.Parse(tempoDec.segundos) + pontuacao) + "pts";	
			}else{
				recordTxt.text = PlayerPrefs.GetInt("recorde")+"pts";
			}
		JogoIniciado = false;
		}
	}
}