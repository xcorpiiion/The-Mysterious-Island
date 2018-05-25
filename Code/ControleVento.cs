using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVento : MonoBehaviour {

    public WindZone vento; // pega o controle de vento

    public float ventoMin, ventoMax; // determina a força do vento

    public Terrain terreno;

    public int loop;

    private AudioSource audioS;


    // Use this for initialization
    void Start () {
        audioS = GetComponent<AudioSource>();
        vento.windMain = ventoMin;
        terreno.terrainData.wavingGrassStrength = 0.1f;
        StartCoroutine("windController");
    }

    IEnumerator windController()
    {
        yield return new WaitForSeconds(Random.Range(0, 20)); // tempo aleatorio para iniciar
        loop = Random.Range(1, 4); // sorteia o numero
        if (loop > 1)
        { // verifica se eu tirei um numero igual ou menor ao da porcentagem
            audioS.loop = true;
        }

        audioS.Play();
        vento.windMain = ventoMax;

        for(int i = 0; i <= 6; i++) {
            terreno.terrainData.wavingGrassStrength += 0.6f;
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i <= loop; i++)
        {
            terreno.terrainData.wavingGrassStrength += 0.6f;
            yield return new WaitForSeconds(15f);
        }

        vento.windMain = ventoMin;

        for (int i = 0; i <= 6; i++)
        {
            terreno.terrainData.wavingGrassStrength -= 0.6f;
            yield return new WaitForSeconds(0.1f);
        }

        audioS.loop = false;
        terreno.terrainData.wavingGrassStrength = 0.1f;
        yield return new WaitForSeconds(Random.Range(20, 60)); // tempo aleatorio para iniciar
        StartCoroutine("windController");
    }
}
