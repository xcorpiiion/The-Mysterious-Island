using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valvula : MonoBehaviour {

    public string idValve = "";
    public SystemValve systemValve;
    public Animator anim;
    public bool gira;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	

    public void interacao() {

        if (!gira) {
            systemValve.entrada += idValve;
            gira = true;
            anim.SetBool("girar", true);
            
            
        }
    }
}
