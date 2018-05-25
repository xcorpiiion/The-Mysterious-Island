using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTexture : MonoBehaviour {
    [Header ("Pega os tipos de texturas")]
    public TextureType[] textureTypes;
    private AudioSource audioS;
    private bool haveRenderer = false, terreno = false;
    public GameObject interacao;
    
    /// Variaveis do terreno>
    public TerrainData mTerrenData, mTerrenData2, mTerrenData3;
    public Terrain terrenoFazenda, terrenoCemiterio;
    private int alphaMapWidth, alphaMapHeight;
    private float[,,] mSplatData;
    private int nNumTextures;
    
    /// </fim>

    // Use this for initialization
    void Start() {
        audioS = GetComponent<AudioSource>();

        
        alphaMapWidth = mTerrenData.alphamapWidth;
        alphaMapHeight = mTerrenData.alphamapHeight;
        mSplatData = mTerrenData.GetAlphamaps(0, 0, alphaMapWidth, alphaMapHeight);

        nNumTextures = mSplatData.Length / (alphaMapWidth * alphaMapHeight);


    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, 1.3f)) {
            
            switch(hit.transform.gameObject.tag) {
                case "Terreno":
                    terreno = true;
                    haveRenderer = false;
                    interacao = hit.transform.gameObject;
                    mTerrenData = mTerrenData2;
                    break;
                case "Grama":
                    haveRenderer = true;
                    terreno = false;
                    interacao = hit.transform.gameObject;
                    break;
                case "Pedra":
                    haveRenderer = true;
                    terreno = false;
                    interacao = hit.transform.gameObject;
                    break;
                case "Cemiterio":
                    terreno = true;
                    haveRenderer = false;
                    interacao = hit.transform.gameObject;
                    mTerrenData = mTerrenData3;
                    break;
            }
        }

    }

    public void playSoundStep()
    {

        if (haveRenderer){
            if (interacao != null)

                playMesh(interacao.GetComponent<MeshRenderer>());

        } else if(terreno) {
            if(interacao != null)
                playTerrain();
        }

        
    }

    private void playMesh(MeshRenderer renderer) {
        if(textureTypes.Length > 0) {
            foreach(TextureType type in textureTypes) {
                foreach(Texture tex in type.textura) {
                    if(renderer.material.mainTexture == tex) {
                        AudioClip somPasso = type.footStepSound[Random.Range(0, type.footStepSound.Length)];
                        audioS.PlayOneShot(somPasso);
                    }
                }
            }
        }

    }

    private void playTerrain()
    {
        int terrenIdX = getActiveTerrainTextureId();
        foreach (TextureType type in textureTypes)
        {
            foreach (Texture tex in type.textura)
            {
                if (mTerrenData.splatPrototypes[terrenIdX].texture == tex)
                {
                    AudioClip somPasso = type.footStepSound[Random.Range(0, type.footStepSound.Length)];
                    audioS.PlayOneShot(somPasso);
                }
            }
        }

    }

    private Vector3 converteToSplatMapCoordinate(Vector3 playerPosition) {
        Vector3 vectRect = new Vector3();
        Vector3 vectRect2 = new Vector3();

        Vector3 terrenoPosition = terrenoFazenda.transform.position;

        vectRect.x = ((playerPosition.x - terrenoPosition.x) / terrenoFazenda.terrainData.size.x) * terrenoFazenda.terrainData.alphamapWidth;
        vectRect.z = ((playerPosition.z - terrenoPosition.z) / terrenoFazenda.terrainData.size.z) * terrenoFazenda.terrainData.alphamapHeight;

        Vector3 terrenoPosition2 = terrenoCemiterio.transform.position;

        vectRect2.x = ((playerPosition.x - terrenoPosition.x) / terrenoCemiterio.terrainData.size.x) * terrenoCemiterio.terrainData.alphamapWidth;
        vectRect2.z = ((playerPosition.z - terrenoPosition.z) / terrenoCemiterio.terrainData.size.z) * terrenoCemiterio.terrainData.alphamapHeight;

        return vectRect;

    }

    private int getActiveTerrainTextureId() {
        int rec = 0;
        Vector3 playerPosition = transform.position;
        Vector3 terrenCord = converteToSplatMapCoordinate(playerPosition);
        float comp = 0;
        for(int i = 0; i < nNumTextures; i++) {
            if(comp < mSplatData[(int)terrenCord.z, (int)terrenCord.x, i]) {
                rec = i;
            }
        }

        return rec;
    }

    ////////// classe de texuras **************************

    [System.Serializable]
    public class TextureType {
        [Space (2)]
        [Header ("Da o nome ao grupo de textura")]
        public string nomeGrupo = "";
        [Space(2)]
        [Header("Pega as texturas")]
        public Texture[] textura;
        [Space(2)]
        [Header("Pega os audios")]
        public AudioClip[] footStepSound; 

    }

}
