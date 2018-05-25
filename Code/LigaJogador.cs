using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LigaJogador : MonoBehaviour {

    public GameObject[] ligar;
    private Scene cena;
    private CutScene cutScene;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
            ligar[0].SetActive(false);
            ligar[1].SetActive(false);
            
        
    }

    // Update is called once per frame
    void Update () {
        cena = SceneManager.GetActiveScene();
        if (cena.name == "Fazenda") {
            ligar[0].SetActive(true);
            ligar[1].SetActive(true);
            cutScene.GetComponent<CutScene>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
