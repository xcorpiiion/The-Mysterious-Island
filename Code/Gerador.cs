using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gerador : MonoBehaviour {

    public FpsController fps;
    public GameObject luzes, torre;
    public AudioSource audioSource;
    

	// Use this for initialization
	void Start () {
        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        
    }


    public void interacao() {


        if (this.gameObject.name == "Gerador") {
            if (fps.usouGasolina) {

                fps.exibirMensagemItem("O gerador está com combustivel");
            } else {
                fps.exibirMensagemItem("O gerador está sem combustivel");
            }
        }

        if (this.gameObject.name == "InteracaoTerminal") {
            if (fps.usouBateria) { // verifica se eu usei a bateria
                if (fps.usouGasolina) { // verifica se a gasolina foi usada no gerador
                    CutScene cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
                    fps.usouAlavanca = true;
                    cutScene.cena02();
                    fps.exibirMensagemItem("Terminal foi ligado"); // muda  a mensagem
                    luzes.SetActive(true);
                    audioSource.Play();
                    
                    
                   
                } else {
                    fps.exibirMensagemItem("Não foi possivel ligar o gerador"); // se não usou a gasolina aparece a mensagem de erro
                }
            } else {
                fps.exibirMensagemItem("Terminal sem bateria");
            }
        }

        

    }

}
