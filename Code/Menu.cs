using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private Loading load;
    public GameObject configuracoes, titulo;
    public AudioSource audioS;

	// Use this for initialization
	void Start () {
        load = FindObjectOfType(typeof(Loading)) as Loading;
        titulo.SetActive(true);
        configuracoes.SetActive(false);
        

    }
	
	public void jogar() {

        audioS.Play();
        titulo.SetActive(false);
        configuracoes.SetActive(false);
        audioS.Play();
        

        load.carregarLoading("Fazenda");
    }

    public void configuracao() {

        audioS.Play();
        configuracoes.SetActive(!configuracoes.activeSelf);
        titulo.SetActive(!titulo.activeSelf);
        audioS.Play();

    }

    public void sair()
    {

        audioS.Play();
        Application.Quit();
        audioS.Play();

    }
}
