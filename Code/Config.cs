using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Config : MonoBehaviour {

    private GameController gameController;

    [Header("Valores iniciais")]
    public int resolucaoTela;
    public bool telaCheia;
    public int qualidadeGrafica;
    public int nivelDetalhe;
    public int numFps;

    private int widgetTela, heightTela, intTelaCheia;

    [Header("UI")]
    public Dropdown resolucao;
    public Dropdown qualidade;
    public Dropdown detalhes;
    public Dropdown frame;

    public Terrain terrenoFazenda, terrenoCemiterio;

    private Menu menu;

    public Toggle full;

    private AudioSource audioS;

    // Use this for initialization
    void Start () {

        QualitySettings.vSyncCount = 0;

        menu = FindObjectOfType(typeof(Menu)) as Menu;

        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        audioS = GetComponent<AudioSource>();

        int telaResolution = PlayerPrefs.GetInt("resolucaoTela");
        int graficConfig = PlayerPrefs.GetInt("qualidadeGrafica");
        int detail = PlayerPrefs.GetInt("nivelDetalhe");
        int fullScren = PlayerPrefs.GetInt("telaCheia");
        int frameRate = PlayerPrefs.GetInt("frame");

        bool gcTelaCheia = false;

        if (fullScren == 1)
        {
            gcTelaCheia = true;
        }
        else
        {
            gcTelaCheia = false;
        }

        resolucao.value = telaResolution;
        qualidade.value = graficConfig;
        detalhes.value = detail;
        full.isOn = gcTelaCheia;
        frame.value = frameRate;
    }
	
	public void aplicar() {

        audioS.Play();

        resolucaoTela = resolucao.value;
        telaCheia = full.isOn;

        qualidadeGrafica = qualidade.value;
        nivelDetalhe = detalhes.value;

        numFps = frame.value;

        switch (resolucaoTela) {
            case 0:
                widgetTela = 1920;
                heightTela = 1080;
                break;
            case 1:
                widgetTela = 1366;
                heightTela = 768;
                break;
            case 2:
                widgetTela = 1280;
                heightTela = 720;
                break;
        }

        switch (resolucaoTela)
        {
            case 0:
                widgetTela = 1920;
                heightTela = 1080;
                break;
            case 1:
                widgetTela = 1366;
                heightTela = 768;
                break;
            case 2:
                widgetTela = 1280;
                heightTela = 720;
                break;

        }



        switch (nivelDetalhe)
        {
            case 0:
                terrenoFazenda.detailObjectDensity = 0.1f;
                terrenoCemiterio.detailObjectDensity = 0.1f;
                break;
            case 1:
                terrenoFazenda.detailObjectDensity = 0.3f;
                terrenoCemiterio.detailObjectDensity = 0.3f;
                break;
            case 2:
                terrenoFazenda.detailObjectDensity = 0.6f;
                terrenoCemiterio.detailObjectDensity = 0.6f;
                break;
            case 3:
                terrenoFazenda.detailObjectDensity = 1f;
                terrenoCemiterio.detailObjectDensity = 1f;
                break;
        }

        switch(numFps) {
            case 1:
                Application.targetFrameRate = 30;
                break;
            case 2:
                Application.targetFrameRate = 60;
                break;
        }

        Screen.SetResolution(widgetTela, heightTela, telaCheia);
        QualitySettings.SetQualityLevel(qualidadeGrafica, true);

        armazenarPreferencias();

        
        gameController.janelaOpcoes.SetActive(false);
        gameController.changeState(GameState.GAMEPLAY);

        gameController.usandoOpcoes = false;
        
        if(gameController.scene.name == "Menu") {
            print("foi");
            Menu configuracao = FindObjectOfType(typeof(Menu)) as Menu;
            configuracao.configuracao();
        }


    }


    void armazenarPreferencias() {
        PlayerPrefs.SetInt("resolucaoTela", resolucaoTela);
        PlayerPrefs.SetInt("qualidadeGrafica", qualidadeGrafica);
        PlayerPrefs.SetInt("nivelDetalhe", nivelDetalhe);
        PlayerPrefs.SetInt("frame", numFps);

        if(telaCheia) {
            intTelaCheia = 1;
        } else {
            intTelaCheia = 0;
        }

        PlayerPrefs.SetInt("telaCheia", intTelaCheia);

       
        

    }

    public void sair()
    {

        audioS.Play();
        Application.Quit();
        audioS.Play();

    }

}
