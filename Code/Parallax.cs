using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    public Transform cam, backGraound;
    public float parallaxScale, velocidade;
    private Vector3 destino, previwCamPos; // previwCamPos = serve para eu colocar a posição atual da minha camera

    // Use this for initialization
    void Start () {
        previwCamPos = cam.position;
	}
	
	// Update is called once per frame
	void Update () {
        float paralaxX = (previwCamPos.x - cam.position.x) * parallaxScale; // pega o resultado da soma entre a posição atual da camera e a posição final da camera
        
        destino = new Vector3(backGraound.position.x + paralaxX, backGraound.position.y, backGraound.position.z); // serve para definir a posicao do backGraound
        backGraound.position = Vector3.Lerp(backGraound.position, destino, velocidade * Time.deltaTime); // serve para fazer a movimentação do backGround
        previwCamPos = cam.position; // serve para atualizar a posição da camera
	}
}
