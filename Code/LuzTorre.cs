using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTorre : MonoBehaviour {

    public Light luz;
    public float delay;
    private bool ligar;

	// Use this for initialization
	void Start () {
        luz.enabled = ligar;
        StartCoroutine("piscar");
    }
	
	IEnumerator piscar() {
        print("foi");
        yield return new WaitForSeconds(delay);
        ligar = !ligar;
        luz.enabled = ligar;
        StartCoroutine("piscar");
    }
}
