using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coruja : MonoBehaviour {

    public int porcentagem;
    private AudioSource audioS;

	// Use this for initialization
	void Start () {
        audioS = GetComponent<AudioSource>();
        StartCoroutine("cantarCoruja");
    }
	
	IEnumerator cantarCoruja() {
        yield return new WaitForSeconds(Random.Range(5, 16)); // tempo aleatorio para iniciar
        int rand = Random.Range(0, 100); // sorteia o numero
        if(rand < porcentagem) { // verifica se eu tirei um numero igual ou menor ao da porcentagem
            audioS.Play();
        }

        yield return new WaitForSeconds(5); // chama dnv a função depois de 5 segundos
        StartCoroutine("cantarCoruja");
    }
}
