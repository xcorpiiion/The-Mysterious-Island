using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otimizacao : MonoBehaviour {
    public GameObject[] _OBJETOS;
    private float DistanciaDoPlayer;
    public float DistanciaMaxima = 40;
    
    void Update()
    {
        for (int i = 0; i < _OBJETOS.Length; i++)
        {
            DistanciaDoPlayer = Vector3.Distance(this.transform.position, _OBJETOS[i].transform.position);
            if (DistanciaDoPlayer >= DistanciaMaxima)
            {
                
                if(_OBJETOS[i].gameObject.name == "Tumba" || _OBJETOS[i].gameObject.name == "Tumba02" ||
                    _OBJETOS[i].gameObject.name == "Tumba03" || _OBJETOS[i].gameObject.name == "Tumba04" ) {
                    _OBJETOS[i].GetComponent<Tumba>().enabled = false;
                } else {
                    _OBJETOS[i].GetComponent<ItemInfo>().enabled = false;
                }
            }
            else
            {
                
                if (_OBJETOS[i].gameObject.name == "Tumba" || _OBJETOS[i].gameObject.name == "Tumba02" ||
                    _OBJETOS[i].gameObject.name == "Tumba03" || _OBJETOS[i].gameObject.name == "Tumba04")
                {
                    _OBJETOS[i].GetComponent<Tumba>().enabled = true;
                } else {
                    _OBJETOS[i].GetComponent<ItemInfo>().enabled = true;
                }
            }
        }
    }
}
