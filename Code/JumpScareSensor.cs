using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareSensor : MonoBehaviour {

    public Transform[] spawnPoint; // pontos de respawn
    public GameObject criatura; // pega a criatura

    public float tempoEspera;

    public bool apareceu = false, deixarTransparente; // verifica se apareceu

    public Renderer[] render;
    public Color corA, corB;
    public float step;

	// Use this for initialization
	void Start () {
        criatura.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(deixarTransparente) {
            step += 0.05f;
            foreach (Renderer renderer in render)
            {
                renderer.material.color = Color.Lerp(corA, corB, step);
            }

            if(step >= 0) {
                deixarTransparente = false;
                criatura.SetActive(false);
                apareceu = false;
            }
        }

	}



    private void OnTriggerEnter(Collider other)
    {

        if (apareceu)
        {
            return;
        } else {

            if (other.gameObject.tag == "Player")
            {
                print("Entrou");
                int rand = Random.Range(0, spawnPoint.Length);
                foreach (Renderer renderer in render)
                {
                    renderer.material.color = corA;
                }
                step = 0; // zerou a contagem para ela começar do zero;
                criatura.transform.position = spawnPoint[rand].position;
                criatura.transform.localRotation = spawnPoint[rand].localRotation;
                criatura.SetActive(true);
                apareceu = true;
                StartCoroutine("wait");

            }
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(tempoEspera);
        deixarTransparente = true;
    }

}
