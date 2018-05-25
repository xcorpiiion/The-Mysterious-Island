using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumba : MonoBehaviour {

    public string nomeRosa;
    public FpsController fps;
    public string idTumba = "";
    public char[] idTumbas;
    public ItemInfo item;
    public bool temId;


    // Use this for initialization
    void Start () {
        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        item = FindObjectOfType(typeof(ItemInfo)) as ItemInfo;
    }

    private void Update()
    {
        
        // serve para quando eu estiver em uma determinada tumba, eu possa atribuir o nome do item que está no meu inventario, para a rosa que esta desativada encima da tumba
        if (this.gameObject.name == "Tumba") {
            if (fps.usandoRosa[0]) {

                if (!temId)
                {
                    SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                    valve.entradaTumba[0] += 1;
                    temId = true;
                }
                if (fps.rosas[0].GetComponent<ItemInfo>().nomeItem == nomeRosa) {
                    
                    fps.rosas[0].GetComponent<ItemInfo>().nomeItem = nomeRosa;
                    
                } else {
                    string nomeRosaTemporario = fps.rosas[0].GetComponent<ItemInfo>().nomeItem;
                    fps.rosas[0].GetComponent<ItemInfo>().nomeItem = nomeRosaTemporario;
                    
                }
            } else {
                SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                valve.entradaTumba[0] = null;
                temId = false;
            }
        } else if(this.gameObject.name == "Tumba02") {
            if (fps.usandoRosa[1])
            {
                if (!temId)
                {
                    SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                    valve.entradaTumba[1] += 2;
                    temId = true;
                }
                if (item.nomeItem == nomeRosa)
                {
                    fps.rosas[1].GetComponent<ItemInfo>().nomeItem = nomeRosa;
                }
                else
                {
                    string nomeRosaTemporario = fps.rosas[0].GetComponent<ItemInfo>().nomeItem;
                    fps.rosas[1].GetComponent<ItemInfo>().nomeItem = nomeRosaTemporario;
                    
                }
            } else {
                SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                valve.entradaTumba[1] = null;
                temId = false;
            }
        } else if(this.gameObject.name == "Tumba03") {
            if (fps.usandoRosa[2])
            {
                if (!temId)
                {
                    SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                    valve.entradaTumba[2] += 3;
                    temId = true;
                }
                if (item.nomeItem == nomeRosa)
                {
                    
                    fps.rosas[2].GetComponent<ItemInfo>().nomeItem = nomeRosa;
                }
                else
                {
                    string nomeRosaTemporario = fps.rosas[0].GetComponent<ItemInfo>().nomeItem;
                    fps.rosas[2].GetComponent<ItemInfo>().nomeItem = nomeRosaTemporario;

                }
            } else {
                SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                valve.entradaTumba[2] = null;
                temId = false;
            }
        } else if(this.gameObject.name == "Tumba04") {
            if (fps.usandoRosa[3])
            {
                if (!temId)
                {
                    SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                    valve.entradaTumba[3] += 4;
                    temId = true;
                }
                if (item.nomeItem == nomeRosa)
                {
                    fps.rosas[3].GetComponent<ItemInfo>().nomeItem = nomeRosa;
                }
                else
                {
                    string nomeRosaTemporario = fps.rosas[0].GetComponent<ItemInfo>().nomeItem;
                    fps.rosas[3].GetComponent<ItemInfo>().nomeItem = nomeRosaTemporario;
                }
            } else {
                SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                valve.entradaTumba[3] = null;
                temId = false;
            }
        }

        
    }

    public void interacao() {
        if (this.gameObject.name == "Tumba")
        {
            
                fps.exibirMensagemItem("Tumba da Kefura");
                
            
            
        }

        if (this.gameObject.name == "Tumba02")
        {
            

                fps.exibirMensagemItem("Tumba da Lucy");
                
            

        }

        if (this.gameObject.name == "Tumba03")
        {
            

                fps.exibirMensagemItem("Tumba da Mikaele");
                
            

        }

        if (this.gameObject.name == "Tumba04")
        {
            

                fps.exibirMensagemItem("Tumba da Cristine");
                
            

        }

    }
}
