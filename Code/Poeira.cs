using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poeira : MonoBehaviour {

    public GameObject emissor; // system complety of particle
    public float altitudeMax, altitude, porcentagem;

    public ParticleSystem terra, folha;
    private ParticleSystem.EmissionModule terraEmission;
    private ParticleSystem.EmissionModule folhaEmission;

    public float terraMax, terraMin, folhaMax, folhaMin; 

    // Use this for initialization
    void Start () {
        emissor = GameObject.Find("Plane");
        terraEmission = terra.emission;
        folhaEmission = folha.emission;

        terraMin = terraEmission.rateOverTime.constantMin;
        terraMax = terraEmission.rateOverTime.constantMax;

        folhaMin = folhaEmission.rateOverTime.constantMin;
        folhaMax = folhaEmission.rateOverTime.constantMax;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, altitudeMax * 5)) {
            if (hit.collider.GetComponent<Terrain>()) {
                porcentagem = ((altitude - altitudeMax) / altitudeMax) * -1;
                altitude = hit.distance;
                if (altitude <= altitudeMax) {
                    terraEmission.rateOverTime = new ParticleSystem.MinMaxCurve(terraMin * porcentagem, terraMax * porcentagem);
                    folhaEmission.rateOverTime = new ParticleSystem.MinMaxCurve(folhaMin * porcentagem, folhaMax * porcentagem);
                } else {
                    terraEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0, 0);
                    folhaEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0, 0);
                }
            }   
        } else {
            terraEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0, 0);
            folhaEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0, 0);
        }



        updatePosition();
	}

    private void updatePosition() {
        emissor.transform.position = new Vector3(transform.position.x, transform.position.y - altitude, transform.position.z);
    }
}
