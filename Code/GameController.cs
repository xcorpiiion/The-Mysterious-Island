using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {
       GAMEPLAY, INVENTARIO, ITEMINFO, INTERACAO, CUTSCENE
}

public class GameController : MonoBehaviour {

    public GameState currentState;

    

    /// Responsavel pelo inventario ***********************
    public List<GameObject> chave = new List<GameObject>();
    public List<GameObject> arquivos = new List<GameObject>();
    public GameObject inventoryWindow, janelaOpcoes; // janela do inventario
    public GameObject[] buttons;
    public bool inventoryAberto = false, clickArquivo, usandoOpcoes; // indica se o inventario está aberto ou fechado
    public Image[] slot; // armazena os slotes do inventory
    public Image[] slotArquivos; // armazena os slotes do inventory

    /// </Fim do comendo responsavel pelo inventario> *************

    public Text cutSceneDialogo;

    private Terrain terreno;
    public Scene scene;
    private ItemInfo itemInfo;
    [Space(3)]
    [Header("Pega os objetos que contem scripts interativos na fazenda")]
    public GameObject coletavelFazenda, interacaoFazenda;
    [Header("Pega os objetos que contem scripts interativos no Cemiterio")]
    public GameObject interacaoCemiterio;

    public Terrain terrenoFazenda, terrenoCemiterio;

    public int receberFrame;

    public AudioSource audioSource;
    public AudioClip[] soundClip;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Use this for initialization
    void Start () {

        scene = SceneManager.GetActiveScene();
        setarPreferencias();
        inventoryWindow.SetActive(inventoryAberto); // indica que o inventario irá começar fechado
        janelaOpcoes.SetActive(usandoOpcoes);
        Time.timeScale = 1;
        itemInfo = FindObjectOfType(typeof(ItemInfo)) as ItemInfo;
        audioSource = GetComponent<AudioSource>();

    }

	
	// Update is called once per frame
	void Update () {


        Cursor.lockState = CursorLockMode.Confined;

        itemInfo = FindObjectOfType(typeof(ItemInfo)) as ItemInfo;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Cemiterio")
        {
            coletavelFazenda.SetActive(false);
            interacaoFazenda.SetActive(false);
            interacaoCemiterio.SetActive(true);

        } else {
            coletavelFazenda.SetActive(true);
            interacaoFazenda.SetActive(true);
            interacaoCemiterio.SetActive(false);
        }

        if (Input.GetButtonDown("Inventario") && currentState != GameState.ITEMINFO && currentState != GameState.INTERACAO && currentState != GameState.CUTSCENE)
        {

            carregarInventario(); // carrega o invenrario
            if(inventoryAberto == false) {
                buttons[2].SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && currentState != GameState.ITEMINFO && currentState != GameState.CUTSCENE && currentState != GameState.INVENTARIO) {
            usandoOpcoes = !usandoOpcoes;
            janelaOpcoes.SetActive(usandoOpcoes);
            if(usandoOpcoes) {
                changeState(GameState.INTERACAO);
            } else {
                changeState(GameState.GAMEPLAY);
            }
        }

        Scene cena = SceneManager.GetActiveScene();

        if (cena.name == "Fazenda")
        {
            coletavelFazenda.SetActive(true);
            interacaoFazenda.SetActive(true);
            interacaoCemiterio.SetActive(false);
        }
        else
        {
            coletavelFazenda.SetActive(false);
            interacaoFazenda.SetActive(false);
            interacaoCemiterio.SetActive(true);
        }


        if(receberFrame != Application.targetFrameRate) {
            Application.targetFrameRate = receberFrame;
        }

    }

    // muda o estado do jogo
    public void changeState(GameState newState) {
        currentState = newState; // recebe o novo estado do jogo
        // verifica se o inventario está aberto
        if (currentState == GameState.INVENTARIO || currentState == GameState.INTERACAO) {
            Time.timeScale = 0; // encerra a passagem de tempo do jogo
        } else {
            Time.timeScale = 1; 
        }
    }



    // usa o inventario ***********************
    public void carregarInventario()
    {
        inventoryAberto = !inventoryAberto;
        inventoryWindow.SetActive(inventoryAberto);
        buttons[0].SetActive(inventoryAberto);
        buttons[1].SetActive(inventoryAberto);

        switch (inventoryAberto)
        {
            case true:
                changeState(GameState.INVENTARIO);
                int i = 0;
                foreach (GameObject item in chave)
                {
                    slot[i].sprite = item.GetComponent<ItemInfo>().imageItem;
                    slot[i].GetComponent<Slot>().itemSlot = item.GetComponent<ItemInfo>();
                    
                    i++;
                }

                i = 0;
                foreach (GameObject item in arquivos)
                {
                    slotArquivos[i].sprite = item.GetComponent<ItemInfo>().imageItem;
                    slotArquivos[i].GetComponent<Slot>().itemSlot = item.GetComponent<ItemInfo>();
                    i++;
                }

                break;
            case false:
                changeState(GameState.GAMEPLAY);
                foreach (Image img in slot)
                {
                    img.sprite = null;
                }

                foreach (Image img in slotArquivos)
                {
                    img.sprite = null;
                }
                break;
        }
    }

    public void atualizarInventory()
    {
        foreach (Image img in slot)
        {
            img.sprite = null;
            img.GetComponent<Slot>().itemSlot = null;
        }

        foreach (Image img in slotArquivos)
        {
            img.sprite = null;
            img.GetComponent<Slot>().itemSlot = null;
        }

        int i = 0;
        foreach (GameObject item in chave)
        {
            slot[i].sprite = item.GetComponent<ItemInfo>().imageItem;
            slot[i].GetComponent<Slot>().itemSlot = item.GetComponent<ItemInfo>();
            i++;
            
        }

        

        i = 0;
        foreach (GameObject item in arquivos)
        {
            slotArquivos[i].sprite = item.GetComponent<ItemInfo>().imageItem;
            slotArquivos[i].GetComponent<Slot>().itemSlot = item.GetComponent<ItemInfo>();
            i++;
        }

    }



    public void itens()
    {
        audioSource.Play();
        inventoryWindow.SetActive(true);
        buttons[2].SetActive(false);
        clickArquivo = false;
    }

    public void arquivosWindow()
    {
        audioSource.Play();
        inventoryWindow.SetActive(false);
        buttons[2].SetActive(true);
        clickArquivo = true;
    }

    // fim usar inventario ************************

    private void setarPreferencias() {
        
        int resolucaoTela = PlayerPrefs.GetInt("resolucaoTela");
        int qualidadeGrafica = PlayerPrefs.GetInt("qualidadeGrafica");
        int nivelDetalhe = PlayerPrefs.GetInt("nivelDetalhe");
        int telaCheia = PlayerPrefs.GetInt("telaCheia");
        int widgetTela = 1280, heightTela = 720;
        int frame = PlayerPrefs.GetInt("frame");

        bool gcTelaCheia = false;

        if (telaCheia == 1)
        {
            gcTelaCheia = true;
        }
        else
        {
            gcTelaCheia = false;
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

        switch(frame) {
            case 1:
                receberFrame = 30;
                break;
            case 2:
                receberFrame = 60;
                break;
        }

        Screen.SetResolution(widgetTela, heightTela, gcTelaCheia);
        QualitySettings.SetQualityLevel(qualidadeGrafica, true);

    }

}
