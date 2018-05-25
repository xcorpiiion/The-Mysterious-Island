using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

    private FpsController fps;

	// Use this for initialization
	void Start () {
        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
	}
	
	public void interacao() {
        if (fps.usouIPilha) {
            if(fps.usouIsqueiro) {
                bool viuCena = false;
                if (!viuCena)
                {
                    CutScene cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
                    cutScene.cena07();
                } else {
                    fps.exibirMensagemItem("Vá embora da ilha");
                }
            } else {
                fps.exibirMensagemItem("Investigue como acabar com a maldição");
            }
        } else {
            fps.exibirMensagemItem("Rádio sem Pilha");
        }
    }
}
