using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {

    public List<string> dialogos = new List<string>();
    public List<int> delayDialogos = new List<int>();
    private GameController gameController;
    private FpsController fps;

    
    public GameObject hud, criatura, helicoptero;

    public PlayableDirector[] diretorCutscene;

    public string nameScene;
    public GameObject[] allCenas;
    public bool vendoCena;

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        vendoCena = true;
        cena01();
        
    }

    private void Update()
    {
        
        if(!vendoCena) {

            switch (nameScene)
            {
                case "Cena 01":

                    
                    if (diretorCutscene[0].time >= diretorCutscene[0].duration - 0.2f)
                    {
                        gameController.cutSceneDialogo.enabled = false;
                        allCenas[0].SetActive(false);
                        fps.cameraFps.SetActive(true);
                        fps.energyBar.enabled = true;
                        fps.clara.SetActive(true);
                        hud.SetActive(true);
                        gameController.changeState(GameState.GAMEPLAY);
                        nameScene = null;
                        dialogos.Remove("Elizabeth: Eu me chamo Elizabeth e eu sou uma investigadora.");
                        dialogos.Remove("Elizabeth: Fui chamada para investigar o desaparecimento de uma jovem, em uma ilha.");
                        dialogos.Remove("Elizabeth: Este será o meu primeiro caso em um lugar distante.");
                        dialogos.Remove("Elizabeth: Tem alguns boatos que dizem que a ilha foi abandonada, por qual razão a ilha foi abandonada?");
                        dialogos.Remove("Elizabeth: Espero que tudo ocorra bem.");
                        helicoptero.SetActive(false);
                        fps.movimentos.SetActive(true);
                        StartCoroutine("mostraMovimentos");
                    }

                    break;

                case "Cena 02":
                    
                    if (diretorCutscene[1].time >= diretorCutscene[1].duration - 0.2f)
                    {
                        
                        gameController.cutSceneDialogo.enabled = false;
                        allCenas[1].SetActive(false);
                        fps.cameraFps.SetActive(true);
                        fps.energyBar.enabled = true;
                        fps.clara.SetActive(true);
                        hud.SetActive(true);
                        gameController.changeState(GameState.GAMEPLAY);
                        nameScene = null;
                    }

                    break;

                case "Cena 03":


                    if (diretorCutscene[2].time >= diretorCutscene[2].duration - 0.2f)
                    {
                        gameController.cutSceneDialogo.enabled = false;
                        allCenas[2].SetActive(false);
                        fps.cameraFps.SetActive(true);
                        fps.energyBar.enabled = true;
                        fps.clara.SetActive(true);
                        hud.SetActive(true);
                        gameController.changeState(GameState.GAMEPLAY);
                        nameScene = null;
                        dialogos.Remove("Elizabeth: Então este local é o cemitério...");
                        dialogos.Remove("Elizabeth: Meu Deus que local sinistro...");
                        dialogos.Remove("Elizabeth: Está completamente escuro, espero que tudo ocorra bem. ");
                    }

                    break;

                case "Cena 04":


                    if (diretorCutscene[3].time >= diretorCutscene[3].duration - 0.2f)
                    {
                        gameController.cutSceneDialogo.enabled = false;
                        allCenas[3].SetActive(false);
                        fps.cameraFps.SetActive(true);
                        fps.energyBar.enabled = true;
                        fps.clara.SetActive(true);
                        hud.SetActive(true);
                        criatura.SetActive(false);
                        gameController.changeState(GameState.INVENTARIO);
                        nameScene = null;
                        
                    }

                    break;

                case "Cena 05":


                    if (diretorCutscene[4].time >= diretorCutscene[4].duration - 0.2f)
                    {
                        gameController.cutSceneDialogo.enabled = false;
                        allCenas[4].SetActive(false);
                        fps.cameraFps.SetActive(true);
                        fps.energyBar.enabled = true;
                        fps.clara.SetActive(true);
                        hud.SetActive(true);
                        gameController.changeState(GameState.GAMEPLAY);
                        nameScene = null;

                    }

                    break;


                case "Cena 08":


                    if (diretorCutscene[5].time >= diretorCutscene[5].duration - 0.2f)
                    {
                        gameController.cutSceneDialogo.enabled = false;
                        allCenas[5].SetActive(false);
                        nameScene = null;
                        
                        cena09();

                    }

                    break;

                case "Cena 09":


                    if (diretorCutscene[6].time >= diretorCutscene[6].duration - 0.2f)
                    {
                        SceneManager.LoadScene("Venceu");
                        Destroy(fps.gameObject);
                        Destroy(gameController.gameObject);
                    }

                    break;

                case "Cena 10":


                    if (diretorCutscene[7].time >= diretorCutscene[7].duration - 0.2f)
                    {
                        SceneManager.LoadScene("Game Over");
                        Destroy(fps.gameObject);
                        Destroy(gameController.gameObject);
                    }

                    break;

            }
        }

        
    }

    private void cena01() {

        
        dialogos.Add("Elizabeth: Eu me chamo Elizabeth e eu sou uma investigadora.");
        dialogos.Add("Elizabeth: Fui chamada para investigar o desaparecimento de uma jovem, em uma ilha.");
        dialogos.Add("Elizabeth: Este será o meu primeiro caso em um lugar distante.");
        dialogos.Add("Elizabeth: Tem alguns boatos que dizem que a ilha foi abandonada, por qual razão a ilha foi abandonada?");
        dialogos.Add("Elizabeth: Espero que tudo ocorra bem.");
        
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 01";
        vendoCena = true;
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        fps.clara.SetActive(false);
        gameController.inventoryWindow.SetActive(false);
        StartCoroutine("delayMensagens");
        
    }

    public void cena02() {

        hud.SetActive(false);
        allCenas[1].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 02";
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        fps.clara.SetActive(false);
        gameController.inventoryWindow.SetActive(false);
        vendoCena = false;
        diretorCutscene[1].Play();
    }


    public void cena03()
    {
        
        if (fps.cutSceneCemiterio == 1)
        {
            
            allCenas[2].SetActive(true);
            dialogos.Add("Elizabeth: Então este local é o cemitério...");
            dialogos.Add("Elizabeth: Meu Deus que local sinistro...");
            dialogos.Add("Elizabeth: Está completamente escuro, espero que tudo ocorra bem. ");
            
            gameController.changeState(GameState.CUTSCENE);
            nameScene = "Cena 03";
            fps.cameraFps.SetActive(false);
            fps.energyBar.enabled = false;
            gameController.inventoryWindow.SetActive(false);
            fps.clara.SetActive(false);
            StartCoroutine("delayMensagens");
        }
    }

    public void cena04() {
        hud.SetActive(false);
        allCenas[3].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        
        nameScene = "Cena 04";
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        gameController.inventoryWindow.SetActive(false);
        fps.clara.SetActive(false);
        vendoCena = false;
        diretorCutscene[3].Play();
    }

    public void cena05()
    {
        hud.SetActive(false);
        allCenas[4].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 05";
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        fps.clara.SetActive(false);
        gameController.inventoryWindow.SetActive(false);
        vendoCena = false;
        diretorCutscene[4].Play();
    }

    public void cena06()
    {


        dialogos.Add("Elizabeth: Sou eu a Elizabeth.");
        dialogos.Add("Rádio: Oh! Elizabeth...");
        dialogos.Add("Rádio: Conseguiu resolver o que aconteceu na ilha?");
        dialogos.Add("Elizabeth: Eu descobri algumas coisas.");
        dialogos.Add("Elizabeth: Parece que um homem chamado Chris, matou 4 garotas...");
        dialogos.Add("Elizabeth: Esse cara é um serial Killer, parece que ele sequestra garotas, abusa delas e depois mata elas para não levantar suspeitas.");
        dialogos.Add("Elizabeth: Uma destas garotas chama-se Cristine, parece que ela ficou com tanto ódio que seu espirito ficou preso na ilha.");
        dialogos.Add("Rádio: Entendo... Como será que isso aconteceu?");
        dialogos.Add("Elizabeth: Das 4 garotas, apenas uma não teve o corpo enterrado ou cremado, será que isso tem a ver com o motivo dela está presa?");
        dialogos.Add("Rádio: É uma possibilidade, tente descobrir como acabar com está maldição, após conseguir, entre em contato novamente, para mim dá as instruções para você.");
        dialogos.Add("Elizabeth: Certo irei liberta-la.");
        allCenas[5].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 06";
        vendoCena = true;
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        gameController.inventoryWindow.SetActive(false);
        fps.clara.SetActive(false);
        gameController.buttons[0].SetActive(false);
        gameController.buttons[1].SetActive(false);
        StartCoroutine("delayMensagens");

    }

    public void cena07()
    {


        dialogos.Add("Elizabeth: Consegui libertar o espirito dela, agora a ilha está liberta.");
        dialogos.Add("Rádio: Certo, bom trabalho.");
        dialogos.Add("Elizabeth: E agora como faço para chamar o resgate?");
        dialogos.Add("Rádio: Caso você tenha um sinalizador, procure por uma área sem arvores e procure um local onde você possa encaixar o sinalizador...");
        dialogos.Add("Rádio: Após isso, use o sinalizador que o resgate aparecera para buscar você.");
        dialogos.Add("Elizabeth: Certo, obrigada.");
        allCenas[5].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 07";
        vendoCena = true;
        fps.cameraFps.SetActive(false);
        gameController.inventoryWindow.SetActive(false);
        fps.energyBar.enabled = false;
        fps.clara.SetActive(false);
        gameController.buttons[0].SetActive(false);
        gameController.buttons[1].SetActive(false);
        StartCoroutine("delayMensagens");

    }

    public void cena08()
    {
        hud.SetActive(false);
        allCenas[6].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 08";
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        fps.clara.SetActive(false);
        vendoCena = false;
        gameController.inventoryWindow.SetActive(false);
        diretorCutscene[5].Play();
    }

    public void cena09()
    {
        hud.SetActive(false);
        allCenas[7].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 09";
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        fps.clara.SetActive(false);
        vendoCena = false;
        gameController.inventoryWindow.SetActive(false);
        diretorCutscene[6].Play();
    }

    public void cena10()
    {
        hud.SetActive(false);
        allCenas[8].SetActive(true);
        gameController.changeState(GameState.CUTSCENE);
        nameScene = "Cena 10";
        fps.cameraFps.SetActive(false);
        fps.energyBar.enabled = false;
        fps.clara.SetActive(false);
        vendoCena = false;
        gameController.inventoryWindow.SetActive(false);
        diretorCutscene[7].Play();
    }

    IEnumerator delayMensagens() {
        foreach (string msg in dialogos) {
            gameController.cutSceneDialogo.text = msg;
            gameController.cutSceneDialogo.enabled = true;
            int temp = 5;
            yield return new WaitForSecondsRealtime(temp);
            
        }

        switch (nameScene)
        {

            case "Cena 01":
                vendoCena = false;
                gameController.cutSceneDialogo.enabled = false;
                diretorCutscene[0].Play();
                break;


            case "Cena 03":

                vendoCena = false;
                gameController.cutSceneDialogo.enabled = false;
                diretorCutscene[2].Play();
                break;

            case "Cena 06":

                gameController.cutSceneDialogo.enabled = false;
                dialogos.Remove("Elizabeth: Sou eu a Elizabeth.");
                dialogos.Remove("Rádio: Oh! Elizabeth...");
                dialogos.Remove("Rádio: Conseguiu resolver o que aconteceu na ilha?");
                dialogos.Remove("Elizabeth: Eu descobri algumas coisas.");
                dialogos.Remove("Elizabeth: Parece que um homem chamado Chris, matou 4 garotas...");
                dialogos.Remove("Elizabeth: Esse cara é um serial Killer, parece que ele sequestra garotas, abusa delas e depois mata elas para não levantar suspeitas.");
                dialogos.Remove("Elizabeth: Uma destas garotas chama-se Cristine, parece que ela ficou com tanto ódio que seu espirito ficou preso na ilha.");
                dialogos.Remove("Rádio: Entendo... Como será que isso aconteceu?");
                dialogos.Remove("Elizabeth: Das 4 garotas, apenas uma não teve o corpo enterrado ou cremado, será que isso tem a ver com o motivo dela está presa?");
                dialogos.Remove("Rádio: É uma possibilidade, tente descobrir como acabar com está maldição, após conseguir, entre em contato novamente, para mim dá as instruções para você.");
                dialogos.Remove("Elizabeth: Certo irei liberta-la.");
                allCenas[5].SetActive(false);
                fps.cameraFps.SetActive(true);
                fps.energyBar.enabled = true;
                fps.clara.SetActive(true);
                hud.SetActive(true);
                gameController.inventoryWindow.SetActive(true);
                gameController.buttons[0].SetActive(true);
                gameController.buttons[1].SetActive(true);
                gameController.changeState(GameState.INTERACAO);
                nameScene = null;

                break;
            case "Cena 07":

                gameController.cutSceneDialogo.enabled = false;
                dialogos.Add("Elizabeth: Consegui libertar o espirito dela, agora a ilha está liberta.");
                dialogos.Add("Rádio: Certo, bom trabalho.");
                dialogos.Add("Elizabeth: E agora como faço para chamar o resgate?");
                dialogos.Add("Rádio: Caso você tenha um sinalizador, procure por uma área sem arvores e procure um local onde você possa encaixar o sinalizador...");
                dialogos.Add("Rádio: Após isso, use o sinalizador que o resgate aparecera para buscar você.");
                dialogos.Add("Elizabeth: Certo, obrigada.");
                allCenas[5].SetActive(false);
                fps.cameraFps.SetActive(true);
                fps.energyBar.enabled = true;
                fps.clara.SetActive(true);
                hud.SetActive(true);
                gameController.inventoryWindow.SetActive(true);
                gameController.buttons[0].SetActive(true);
                gameController.buttons[1].SetActive(true);
                gameController.changeState(GameState.INVENTARIO);
                nameScene = null;

                Radio radio = FindObjectOfType(typeof(Radio)) as Radio;
                radio.gameObject.tag = "Untagged";

                break;

        }
        

    }


    IEnumerator mostraMovimentos() {
        gameController.changeState(GameState.CUTSCENE);
        yield return new WaitForSeconds(15);
        gameController.changeState(GameState.GAMEPLAY);
        fps.movimentos.SetActive(false);
    }

}
