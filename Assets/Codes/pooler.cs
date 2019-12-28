using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooler : MonoBehaviour
{

    public GameObject[] objetosPooleds;
    public GameObject bolsaVazia;
    GameObject[] bolsas;


    void Start () {
        bolsas = new GameObject[objetosPooleds.Length];
		for(int i = 0;objetosPooleds.Length>i;i++){
			bolsas[i] = Instantiate(bolsaVazia);
			bolsas[i].transform.parent = gameObject.transform;
		}
	}

    void Update()
    {
    }

    public GameObject pegarObjeto(int code, Vector3 posicao, Quaternion rotacao)
    {
        GameObject pedido = null;
        bool inst = true;

        for (int i = 0; bolsas[code].transform.childCount > i; i++)
        {
            if(!bolsas[code].transform.GetChild(i).gameObject.active){
				pedido = bolsas[code].transform.GetChild(i).gameObject;
                inst = false;
				break;
			}
        }
		if(inst){
			GameObject temp;
			temp = Instantiate(objetosPooleds[code],posicao,rotacao);
			temp.transform.parent = bolsas[code].transform;
            pedido = temp;
		}
        pedido.transform.position = posicao;
        pedido.transform.rotation = rotacao;
        for(int i = 0;pedido.transform.childCount>i;i++){
            pedido.transform.GetChild(i).gameObject.SetActive(true);
        }
        pedido.SetActive(true);
        return pedido;
    }
}