using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AiInimigo : MonoBehaviour {
    private FpsController fps;

    // Use this for initialization
    void Start () {
        
        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        

            
            // faz a criatura ficar olhando para mim o tempo todo
            Vector3 direcao = (fps.transform.position - transform.position).normalized;
            Quaternion lookAt = Quaternion.LookRotation(new Vector3(direcao.x, 0, direcao.z));
            transform.localRotation = lookAt;

        

    }

    
}
