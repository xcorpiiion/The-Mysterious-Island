using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour {

    public string nomeItem, descricao;
    public Sprite imageItem;
    public bool clicavel = false, visivil = false, removivel = false;
    bool desativar = false;
    public FpsController fps;
    public Pilha pilha;

    private void Start()
    {
        pilha = FindObjectOfType(typeof(Pilha)) as Pilha;
        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        if (!visivil) {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<Light>().enabled = false;
            this.gameObject.tag = "Untagged";
        }
        switch(this.gameObject.name) {
            case "Carta da familia wong":
                descricao = "Estamos abandonando a nossa casa e levando o principal com a gente... \n" +
                    "Estamos deixando uma câmera e uma pilha, caso alguém queira ver essa aparição, pois ela só é visível pela câmera.";
                break;
            case "Carta da familia":
                descricao = "Não aguentamos mais, essa aparição aparece quando menos esperamos... \n" +
                    "O estranho é que essa aparição parece com aquela mulher... \n" + "Será que aquela mulher morreu?";
                break;
            case "Carta do Will":
                descricao = "Sempre me perguntei o que será que tem atrás desta porta com senha que o meu pai tanto esconde... \n" +
                    "Meu pai sempre disse que a senha tem 5 dígitos e que a senha seria referente ao número de coisas que temos em casa... \n" +
                    "Estranho pois temos 2 quartos, 3 portas, 1 maquina, 1 estante, 7 janelas e 1 painel eletrônico... \n" +
                    "Esses números, pertencem a senha... \n" + "Me pergunto qual é a ordem dos 5 dígitos...";
                break;
            case "Carta do pai":
                descricao = "Eu sempre esqueço a senha do painel eletrônico, pois nunca fui bom para lembrar números, como eu não quero que ninguém saiba fiz esse enigma... \n" +
                    "A combinação da senha é a seguinte: \n" +
                    "A SOMA DE 4 NÚMEROS, É O PRIMEIRO DIGITO \n" +
                    "A SOMA DE 2 NÚMEROS, MENOS O PRIMEIRO DIGITO, É O SEGUNDO DIGITO \n" +
                    "A SUBTRAÇÃO DO SEGUNDO DIGITO COM UM NÚMERO, É O TERCEIRO DIGITO" +
                    "A SOMA DO TERCEIRO DIGITO COM UM NÚMERO, É O QUARTO DIGITO \n" +
                    "A SUBTRAÇÃO DO QUARTO DIGITO COM TERCEIRO DIGITO, É O ULTIMO DIGITO. \n" +
                    "Os números negativos têm que ser tratados como positivos. \n" +
                    "A soma dos 5 dígitos, dividido por 2, tem como resultado o número 7.";
                break;
            case "Família Valentine":
                descricao = "Essa mulher chamada Cristine é muito estranha, ela esteve na casa dos Wong e agora apareceu na frente da minha casa. Minha esposa e eu desconfiamos dela..." +
                    "Ela parecia apavorada, o que será que essa mulher tinha para ficar assim...";
                break;
            case "Família Kennedy":
                descricao = "Nós moramos nesta casa por mais de 20 anos, em todos esses anos nunca tínhamos visto nada deste tipo... \n" +
                    "Sim depois que aquela mulher misteriosa morreu, tudo em nossas vidas mudou, fomos forçados a abandonar à nossa casa e tudo o que conquistamos...";
                break;
            case "Família Wong":
                descricao = "Uma mulher misteriosa chamada Cristine apareceu em nossa casa pedindo por comida...\n" +
                    "Ela estava toda molhada e estava muito frio...\n" +
                    "Eu e a minha esposa decidimos deixar ela passar a noite em nossa casa...\n" +
                    "Ela parecia está fugindo de alguma coisa ou de alguém..." +
                    "Perguntei para ela se tinha alguma coisa errada, ela respondeu que não..." +
                    "Me pergunto o que será que aconteceu com ela...";
                break;

            case "Família que fugiu da casa":
                descricao = "Parece que além da Cristine houveram mais 3 vítimas, mais 3 mulheres...\n" +
                    "Parece que Lucy morreu primeiro que a Mikaele, Mikaele morreu depois da Kefura e parece que a Cristine foi a última vítima...\n" +
                    "Me pergunto como elas morreram.";
                break;
            case "Homem que viu o corpo das vítimas":
                descricao = "Eu encontrei o corpo de 3 garotas mortas, parece que a primeira morreu espancada, a segunda morreu enforcada e a terceira morreu com após ter o pescoço quebrado..." +
                    "Mas ainda teve uma quarta vítima.." + "Eu não encontrei o corpo desta garota que morreu.";
                break;
            case "Pedido de ajuda":
                descricao = "Se alguém estiver lendo está carta, me ajude por favor... \n" + "Este louco me estrupa e me bate...\n" +
                    "Consegui escapar em um momento de distração dele, mas ele está atrás de mim, ele vai me matar...\n" +
                    "Ele é louco, gosta de tortura, meu Deus...\n" + "Socorro...";
                break;
            case "Chris":
                descricao = "Tive que matar aquela maldita antes que ela abrir-se aquela boca, é muito arriscado deixar o corpo dela por aqui como eu fiz com as outras 3...\n" +
                    "Já sei, vou colocar o corpo dela no cemitério, assim ninguém irá suspeitar.";
                break;
            case "Pessoa Misteriosa":
                descricao = "Coloquei esse sistema aqui para evitar que alguém tente procurar o que não deve... \n" + "Tem coisas aqui que não devem ser achadas.";
                break;
            case "Filho dos Valentine":
                descricao = "A família do Will estava indo embora por causa desses eventos estranhos, ele me deu a chave do quarto dele caso eu queira ir para lá algum dia..."
                    + "É uma pena que isso ele tenha que abandonar o lar dele.";
                break;
            case "Cristine":
                descricao = "Meu Deus, ele já matou outras garotas antes de mim...\n" + "Ele é um serial killer, ele sequestra garotas e traz para está ilha...";
                break;
            case "Carta de Chris":
                descricao = "Algo estranho aconteceu após matar aquela mulher, parece que o ódio dela em relação a mim e a tudo o que eu fiz cresceu tanto, que o espirito dela busca vingança...\n" +
                    "Eu não posso me livrar dele, pois seria muito suspeito...\n" + "Apenas irei fugir com a minha família e começar uma nova vida...\n" +
                    "irei sumir e nunca irão descobrir os meus crimes...\n" + "Talvez a única forma de se livrar dela é destruindo seus restos, mas isso não me interesse, já estarei longe daqui... \n" +
                    "Serei um homem livre e irei procurar outra vítima...";
                break;

            case "Diario de Chris":
                descricao = "Matei aquela mulheres, os vizinhos estão com suspeitas de mim... \n" +
                    "Preciso ir embora logo, acho que irei para a cidade grande... \n" +
                    "Me livrei o maximo possível de provas contra mim e ainda fiz diversos enigmas para não descobrirem a verdade..." +
                    "Nunca irão saber a verdade";
                break;
            
        }
    }

    private void FixedUpdate()
    {
        if (fps.ligarCamera)
        {
            if (!visivil) {

                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                this.gameObject.GetComponent<Light>().enabled = true;
                this.gameObject.tag = "Arquivos";
                desativar = false;
            }
            
        } else if(!desativar && !visivil){
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<Light>().enabled = false;
            this.gameObject.tag = "Untagged";
            desativar = true;
        }

        
    }


    public void usarItem() {
        
        switch (nomeItem) {
            case "Bateria Lanterna":
                if (fps.carga < fps.maxCarga)
                {
                    fps.recarregar(pilha.carga);
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    painel.removeItem();
                }
                break;
            case "Pilha":

                if (fps.cargaCamera < fps.maxCargaCamera)
                {

                    fps.recarregarCamera(pilha.carga);
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    painel.removeItem();
                }
                break;

            case "Gasolina":
                GameController gameController = FindObjectOfType(typeof(GameController)) as GameController;
                if(fps.usarGasolina) {
                    
                    gameController.audioSource.clip = gameController.soundClip[1];
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    painel.removeItem();
                    fps.exibirMensagemItem("O gerador está com gasolina");
                    fps.usouGasolina = true;
                }
                break;
            case "Bateria do Terminal":

                
                if (fps.usarBateria)
                {
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    painel.removeItem();
                    fps.usouBateria = true;
                }
                break;
            case "Alcool":

                
                if (fps.usarAlcool)
                {
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    painel.removeItem();
                    fps.usouAlcool = true;
                }
                break;

            case "Isqueiro":
                if (fps.usarAlcool) {
                    if (fps.usouAlcool)
                    {
                        ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                        painel.removeItem();
                        CutScene cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
                        cutScene.cena05();
                    }
                    fps.usouIsqueiro = true;
                }
                break;
            case "Pilha do radio":
                
                    if (fps.usarPilha)
                    {
                        ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                        painel.removeItem();
                        CutScene cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
                        cutScene.cena06();
                    }
                    fps.usouIPilha = true;
                
                break;

            case "Sinalizador":

                if (fps.usarSinalizador)
                {
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    painel.removeItem();
                    CutScene cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
                    cutScene.cena08();
                }
                fps.usouSinalizador = true;

                break;

            // serve para usar a rosa sobre a tumba, assim ativando a rosa que está desativada encima da tumba
            case "Rosa da Cristine":
                if (fps.usarRosa)
                {
                    
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    switch (fps.nomeTumba)
                    {
                        case "Tumba":
                            if (!fps.usandoRosa[0])
                            {
                                
                                fps.rosas[0].SetActive(true);
                                fps.rosas[0].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                print(nomeItem);
                                fps.usandoRosa[0] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                            }
                            break;
                        case "Tumba02":
                            if (!fps.usandoRosa[1])
                            {
                                fps.rosas[1].SetActive(true);
                                fps.rosas[1].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[1] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;
                        case "Tumba03":
                            if (!fps.usandoRosa[2])
                            {
                                fps.rosas[2].SetActive(true);
                                fps.rosas[2].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[2] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;
                        case "Tumba04":
                            if (!fps.usandoRosa[3])
                            {
                                print("entrou Cristine");
                                fps.rosas[3].SetActive(true);
                                fps.rosas[3].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[3] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;

                            // fim do comando da rosa
                    }
                }
                break;
            case "Rosa da Mikaele":
                if (fps.usarRosa)
                {
                    
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    switch (fps.nomeTumba)
                    {
                        case "Tumba":
                            if (!fps.usandoRosa[0])
                            {
                                fps.rosas[0].SetActive(true);
                                fps.rosas[0].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                print(nomeItem);
                                fps.usandoRosa[0] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                            }
                            break;
                        case "Tumba02":
                            if (!fps.usandoRosa[1])
                            {
                                fps.rosas[1].SetActive(true);
                                fps.rosas[1].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[1] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;
                        case "Tumba03":
                            if (!fps.usandoRosa[2])
                            {
                                print("entrou Mikaele");
                                fps.rosas[2].SetActive(true);
                                fps.rosas[2].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[2] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;
                        case "Tumba04":
                            if (!fps.usandoRosa[3])
                            {
                                fps.rosas[3].SetActive(true);
                                fps.rosas[3].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[3] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;

                            // fim do comando da rosa
                    }
                }
                break;
            case "Rosa da Lucy":
                if (fps.usarRosa)
                {
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    switch (fps.nomeTumba)
                    {
                        case "Tumba":
                            if (!fps.usandoRosa[0])
                            {
                                fps.rosas[0].SetActive(true);
                                fps.rosas[0].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[0] = true;
                                print(nomeItem);
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                            }
                            break;
                        case "Tumba02":
                            if (!fps.usandoRosa[1])
                            {
                                fps.rosas[1].SetActive(true);
                                fps.rosas[1].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[1] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;
                        case "Tumba03":
                            if (!fps.usandoRosa[2])
                            {
                                fps.rosas[2].SetActive(true);
                                fps.rosas[2].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[2] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;
                        case "Tumba04":
                            if (!fps.usandoRosa[3])
                            {
                                fps.rosas[3].SetActive(true);
                                fps.rosas[3].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[3] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                            }
                            break;

                            // fim do comando da rosa
                    }

                }
                break;
            case "Rosa da Kefura":
                if (fps.usarRosa)
                {
                    
                    ItemInfoPainel painel = FindObjectOfType(typeof(ItemInfoPainel)) as ItemInfoPainel;
                    switch (fps.nomeTumba)
                    {
                        case "Tumba":
                            if (!fps.usandoRosa[0])
                            {
                                print("entrou Kefura");
                                fps.rosas[0].SetActive(true);
                                fps.rosas[0].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[0] = true;
                                print(nomeItem);
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                            }
                            break;
                        case "Tumba02":
                            if (!fps.usandoRosa[1])
                            {
                                fps.rosas[1].SetActive(true);
                                fps.rosas[1].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[1] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                                
                            }
                            break;
                        case "Tumba03":
                            if (!fps.usandoRosa[2])
                            {
                                fps.rosas[2].SetActive(true);
                                fps.rosas[2].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[2] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                                
                            }
                            break;
                        case "Tumba04":
                            if (!fps.usandoRosa[3])
                            {
                                fps.rosas[3].SetActive(true);
                                fps.rosas[3].GetComponent<ItemInfo>().nomeItem = nomeItem;
                                fps.usandoRosa[3] = true;
                                painel.removeItem();
                                fps.exibirMensagemItem("O gerador está com gasolina");
                                fps.usarRosa = false;
                                
                            }
                            break;

                            // fim do comando da rosa
                    }
                }
                break;
        }
    }
}
