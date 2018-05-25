using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public bool aberta = false, needKeyOpen = true; // verifica se a porta tem a chave
    public string nameKey;
    private GameController gameController;
    private AudioSource audioS;

    public bool requerSenha = false, puzzle = false;
    public EletroicPanel painelEletronico;
    public SystemValve systemValve;

    private Animator animacao;

    public GameObject ativarItem, ativarItem2;

    public FpsController fps;

    // Use this for initialization
    void Start()
    {
        if (ativarItem != null)
        {
            ativarItem.SetActive(false);
        }

        if (ativarItem2 != null)
        {
            ativarItem2.SetActive(false);
        }


        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        audioS = GetComponent<AudioSource>();
        painelEletronico = FindObjectOfType(typeof(EletroicPanel)) as EletroicPanel;
        systemValve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
        animacao = GetComponent<Animator>();
    }

    private void abrirPorta()
    {

        if (!aberta)
        {
            if (this.gameObject.name != "PortaCemiterio")
            {
                animacao.SetBool("abrirPorta", true);
                audioS.Play();
                GetComponent<MsgInteracao>().messenger = "";

            }
            else
            {
                Scene cena = SceneManager.GetActiveScene();
                Loading load;
                CutScene cutScene;
                cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
                if (cena.name == "Fazenda")
                {
                    this.gameObject.tag = "Door";
                    load = FindObjectOfType(typeof(Loading)) as Loading;
                    fps.cutSceneCemiterio++;
                    load.carregarLoading("Cemiterio");
                    fps.transform.position = new Vector3(-45.179f, 3.20f, -166.2894f);
                    cutScene.cena03();
                }
                else
                {
                    this.gameObject.tag = "Door";
                    load = FindObjectOfType(typeof(Loading)) as Loading;
                    load.carregarLoading("Fazenda");
                    fps.transform.position = new Vector3(63.96f, 28.41f, -185.19f);

                }
            }
        } else {
            if (this.gameObject.name == "PortaCemiterio")
            {
                this.gameObject.tag = "Door";
                aberta = false;
            }
        }

    }

    // interage com a porta
    public void interacao()
    {



        // verifica se a porta precisa de chave ou não
        if (requerSenha && !painelEletronico.open)
        {
            fps.exibirMensagemItem("Precisa da senha para abrir");
        }
        else if (needKeyOpen)
        {
            fps.exibirMensagemItem("Precisa da chave '" + nameKey + "'");
            foreach (GameObject item in gameController.chave)
            {
                print(item);
                if (item.GetComponent<ItemInfo>().nomeItem == nameKey)
                {
                    print("tem");
                    if (this.gameObject.name == "Gaveta Esquerda")
                    {
                        needKeyOpen = false;
                        ativarItem.SetActive(true);
                    }
                    else if (this.gameObject.name == "Gaveta Meio")
                    {
                        needKeyOpen = false;
                        ativarItem.SetActive(true);
                        ativarItem2.SetActive(true);
                    }
                    else if (this.gameObject.name == "Gaveta Direita")
                    {
                        needKeyOpen = false;
                        ativarItem.SetActive(true);

                    }
                    else if (this.gameObject.name == "Tampa")
                    {
                        needKeyOpen = false;
                        ativarItem.SetActive(true);
                        ativarItem2.SetActive(true);
                    }

                    print(nameKey);
                    abrirPorta();
                    aberta = true;
                    this.gameObject.tag = "Untagged";
                    needKeyOpen = false;
                    gameController.chave.Remove(item);

                    if (this.gameObject.name == "PortaCemiterio")
                    {
                        this.gameObject.tag = "Door";
                    }
                    
                }

            }
        }

        else if (painelEletronico.open)
        {
            abrirPorta();
            aberta = true;
            this.gameObject.tag = "Untagged";
        }
        else if (puzzle)
        {
            if (systemValve.resolvido)
            {
                abrirPorta();
                aberta = true;
                this.gameObject.tag = "Untagged";
            }
        }
        else
        {
            abrirPorta();
            if (this.gameObject.name == "Gaveta Esquerda" || this.gameObject.name == "Gaveta Direita" || this.gameObject.name == "Gaveta Meio")
            {
                aberta = true;
                this.gameObject.tag = "Untagged";
            }
        }

    }

}   

    

