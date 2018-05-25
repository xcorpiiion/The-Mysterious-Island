using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EletroicPanel : MonoBehaviour {

    public GameObject hud;
    private GameController gameController;

    public string password; // armazena a senha
    public bool open = false; // verifica se a senha foi digitada corretamente
    private string typedPassword; // armazena os numeros digitados
    public Text display;
    public AudioClip[] clipAudio;
    private AudioSource audioSource;
    

	// Use this for initialization
	void Start () {
        hud.SetActive(false);
        
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        typedPassword = null;
        display.text = typedPassword;
        audioSource = this.GetComponent<AudioSource>();
	}
	
	
    public void interacao() {
        FpsController fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        if (fps.usouAlavanca) {
            hud.SetActive(true);
            gameController.changeState(GameState.INTERACAO);
        } else {
            GetComponent<MsgInteracao>().messenger = "Precisa ligar a energia";
        }
    }

    public void btnNumber(string number) {
        typedPassword += number;
        display.text = typedPassword;
        audioSource.clip = clipAudio[0];
        audioSource.Play();
    }

    public void btnCancel() {
        gameController.changeState(GameState.GAMEPLAY);
        typedPassword = null;
        display.text = null;
        hud.SetActive(false);
        audioSource.clip = clipAudio[0];
        audioSource.Play();
    }

    public void btnEnter() {
        audioSource.clip = clipAudio[0];
        audioSource.Play();
        StartCoroutine("confirmar");
        audioSource.clip = clipAudio[1];
        audioSource.Play();
    }

    IEnumerator confirmar() {
        if(typedPassword == password) {
            audioSource.clip = clipAudio[1];
            audioSource.Play();
            display.text = "OK";
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = null;
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = "OK";
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = null;
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = "OK";
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = null;
            typedPassword = null;
            open = true;
            
            btnCancel();
        } else {
            display.text = "ERROR";
            audioSource.clip = clipAudio[1];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = null;
            audioSource.clip = clipAudio[1];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = "ERROR";
            audioSource.clip = clipAudio[1];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = null;
            audioSource.clip = clipAudio[1];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = "ERROR";
            yield return new WaitForSecondsRealtime(0.2f);
            display.text = null;
            audioSource.clip = clipAudio[1];
            audioSource.Play();
            typedPassword = null;
            audioSource.clip = clipAudio[1];
            audioSource.Play();
        }
    }

}
