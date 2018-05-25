using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfoPainel : MonoBehaviour {
    public ItemInfo itemInfo;
    public Text nomeItem;
    public Image imgItem;
    private GameController gamecontroller;
    public GameObject btnUsar, btnRemove;
    public TMP_Text descricaoItem;
    private AudioSource audioSource;


    // Use this for initialization
    void Start () {
        this.gameObject.SetActive(false);
        gamecontroller = FindObjectOfType(typeof(GameController)) as GameController;
        audioSource = GetComponent<AudioSource>();
	}
	
	public void useItem() {

        audioSource.Play();
        itemInfo.usarItem();

        
    }

    public void removeItem() {
        gamecontroller.audioSource.clip = gamecontroller.soundClip[0];
        gamecontroller.audioSource.Play();
        gamecontroller.chave.Remove(itemInfo.gameObject);
        gamecontroller.atualizarInventory();
        closeInfo();
        gamecontroller.audioSource.clip = gamecontroller.soundClip[0];
        gamecontroller.audioSource.Play();
    }

    public void closeInfo() {
        gamecontroller.audioSource.clip = gamecontroller.soundClip[0];
        gamecontroller.audioSource.Play();
        gamecontroller.currentState = GameState.INVENTARIO;
        this.gameObject.SetActive(false);
        gamecontroller.audioSource.clip = gamecontroller.soundClip[0];
        gamecontroller.audioSource.Play();
    }
}
