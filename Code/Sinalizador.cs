using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sinalizador : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
	}
	
	public void interacao() {

    }

    public void menu() {
        SceneManager.LoadScene("PreTitulo");
    }
}
