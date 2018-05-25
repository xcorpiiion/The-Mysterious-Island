using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {

    private GameController gameController;
    public ItemInfo itemSlot;
    public GameObject panelInfo;
    private ItemInfoPainel itemPainel;
    private ItemInfo itemInfo;
    private AudioSource audioSource;


    private void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(itemSlot != null) {
            audioSource.Play();
            itemPainel = panelInfo.GetComponent<ItemInfoPainel>();
            gameController.currentState = GameState.ITEMINFO;
            itemPainel.nomeItem.text = itemSlot.nomeItem;
            itemPainel.descricaoItem.text = itemSlot.descricao;
            itemPainel.imgItem.sprite = itemSlot.imageItem;
            itemPainel.itemInfo = itemSlot;
            panelInfo.SetActive(true);
            if (!itemSlot.clicavel)
                itemPainel.btnUsar.SetActive(false);
            else
                itemPainel.btnUsar.SetActive(true);

            if (!itemSlot.removivel)
                itemPainel.btnRemove.SetActive(false);
            else
                itemPainel.btnRemove.SetActive(true);

        }

    }
}
