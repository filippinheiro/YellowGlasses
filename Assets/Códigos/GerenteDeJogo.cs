using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenteDeJogo : MonoBehaviour {
	
	private bool jogoChamado = false;
	public bool pauseChamado = false;
	public float dificuldade = 0;
	public bool JogoIniciado = false;
	private GameObject temp;
	public int vidaMax, vidaAgora; 

	public GameObject [] Spawners;
	public float tempoDeSpawn;
	float contador = 0;
	pooler pool;

	public int pontuacao = 0;

	public GameObject canhao, gameScreen;
	public GameObject pauseScreen;
	public GameObject endScreen;
	public Text pontuacaoTxt, recordTxt;
	public pontuacao pont;
	public tempoDecorrido tempoDec;

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
			tentePausar();
			tenteMorrer();
		}
		if(!pauseChamado && pauseScreen.active){
			if(pauseScreen.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Ir para o Lado") && pauseScreen.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > .99f){
				pauseScreen.SetActive(false);
			}	
		}
		
	}

	
	void mecanicasDeJogo(){
		dificuldade += Time.deltaTime*0.02f;
		contador += Time.deltaTime;
		if(contador >= tempoDeSpawn){
			int quantosInimPSpawn = Mathf.CeilToInt(Random.Range(dificuldade,3f));
		int [] locais = new int[quantosInimPSpawn];
			int i = 0;
			while(i<=quantosInimPSpawn-1){
				locais[i] = Mathf.CeilToInt(Random.Range(-1f,2f));
				for(int j = 0;j<locais.Length;j++){
					for(int k = 0; k<locais.Length;k++){
						if(locais[j] != locais[k] || (locais[j] == locais[k] && j==k)){
							pool.pegarObjeto(0,Spawners[locais[i]].transform.position, new Quaternion(0,0,0,0)).GetComponent<Inimigo_Defaut>().chamarInimigo();
							i++;
							break;
						}
					}
				}	
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
		temp = !jogoChamado ? QuemChamou : temp;
		if(!checarAnimacao(QuemChamou)){
			vidaAgora = vidaMax;
			JogoIniciado = true;
			QuemChamou.SetActive(false);
			canhao.SetActive(true);
			gameScreen.SetActive(true);
			gameScreen.GetComponent<Animator>().SetTrigger("Volte");
			pontuacao = 0;
			dificuldade = 0;
		}
		
		jogoChamado = true;
	}

	private bool checarAnimacao(GameObject Objeto){
		Animator anim = Objeto.GetComponent<Animator>();
		if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Parada") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .99f)
		return false;
		else
		return true;
	}

	public void pausarJogo(){
		pauseScreen.SetActive(true);
		pauseChamado = true;
		pauseScreen.GetComponent<Animator>().SetTrigger("Volte"); 
		gameScreen.GetComponent<Animator>().SetTrigger("Saia"); 
	}

	private void tentePausar(){
		Animator anim = pauseScreen.GetComponent<Animator>();
		if(pauseChamado && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .99f && gameScreen.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > .99f && !gameScreen.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Parada")){
			Time.timeScale = 0;
		}
		
	}

	public void despausar(){
		Time.timeScale = 1;
		pauseChamado = false;
		pauseScreen.GetComponent<Animator>().SetTrigger("Saia"); 
		gameScreen.GetComponent<Animator>().SetTrigger("Volte"); 
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
			pontuacaoTxt.text = tempoDec.minutos + "x" +tempoDec.segundos + " = " + int.Parse(tempoDec.minutos) * int.Parse(tempoDec.minutos)+"\n+"+pontuacao+"\n"+(int.Parse(tempoDec.minutos) * int.Parse(tempoDec.minutos) + pontuacao)+"pts";
			if(PlayerPrefs.GetInt("recorde") == 0 || int.Parse(tempoDec.minutos) * int.Parse(tempoDec.minutos) + pontuacao > PlayerPrefs.GetInt("recorde") || PlayerPrefs.GetInt("recorde") == null){
				PlayerPrefs.SetInt("recorde", int.Parse(tempoDec.minutos) * int.Parse(tempoDec.minutos) + pontuacao);
				recordTxt.text = (int.Parse(tempoDec.minutos) * int.Parse(tempoDec.minutos) + pontuacao) + "pts";	
			}else{
				recordTxt.text = PlayerPrefs.GetInt("recorde")+"pts";
			}
		JogoIniciado = false;
		}
	}
}