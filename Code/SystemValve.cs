using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemValve : MonoBehaviour {

    public string solucao; // contem a solução do enigma
    public string entrada, ordemTumbas, senhaPuzzle; // contem o valor que vai ser comparado com a solução ao girar as valvulas
    public bool resolvido;
    public string[] entradaTumba;

    public GameObject[] valves, luzes;


    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
	}
	

    public void interacao() {
        
        FpsController fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        senhaPuzzle = entradaTumba[0] + entradaTumba[1] + entradaTumba[2] + entradaTumba[3];

        if (fps.usouAlavanca)
        {
            if (senhaPuzzle == ordemTumbas)
            {
                if (entrada == solucao)
                {
                    resolvido = true;

                    fps.exibirMensagemItem("Luzes desligadas");
                    CutScene cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
                    cutScene.cena04();
                }
                else
                {

                    fps.exibirMensagemItem("Algo deu errado"); ;
                    entrada = null;
                    foreach (GameObject v in valves)
                    {
                        v.GetComponent<Valvula>().gira = false;
                        v.GetComponent<Valvula>().anim.SetBool("girar", false);
                    }
                }
            }
            else
            {

                fps.exibirMensagemItem("Alguma coisa está errada nas tumbas");
            }
        } else {
            fps.exibirMensagemItem("Está sem energia");
        }
    }
}

