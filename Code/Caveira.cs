using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveira : MonoBehaviour {

    
    private FpsController fps;

    // Use this for initialization
    void Start () {
         fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        
    }


    public void interacao() {
         
        fps.exibirMensagemItem("Parece que este corpo está aqui faz um tempo");
    }
}
