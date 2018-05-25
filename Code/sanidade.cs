using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;




public class sanidade : MonoBehaviour {

	
	private FpsController		fps;
    private JumpScareSensor     jumbScare;

	public	PostProcessingProfile	controle; // pega o controle de efeitos da unity

	public	GlitchEffect			glitch;

	public	float					pixelAmount; // determina o tanto de grain que será usado na camera

	public	float					insanidade;

    public GameObject teste;

	// Use this for initialization
	void Start () {

        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        
        jumbScare = FindObjectOfType(typeof(JumpScareSensor)) as JumpScareSensor;

		var temp = controle.grain.settings; // determina automaticamente o tipo da variavel
		temp.intensity = 0;
		temp.size = 3f;
        temp.luminanceContribution = 0.5f;
		controle.grain.settings = temp;


	}

    private void Update()
    {
        if(!teste.activeInHierarchy) {
            print("ta tudo ok");
            StopCoroutine("alterarSanidade");
            StopCoroutine("erros");
            glitch.enabled = false;
            StartCoroutine("reduzirInsanidade");
        }
    }

    void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "Cristine Aparição")
		{
			StartCoroutine("alterarSanidade"); // chama a coroutine para alterar o grain
			StartCoroutine("erros"); // liga e desliga o glitch

		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.name == "Cristine Aparição")
		{
			StopCoroutine("alterarSanidade");
			StopCoroutine("erros");
			glitch.enabled = false;
            print("Saiu");
			StartCoroutine("reduzirInsanidade");

		}
	}


	IEnumerator erros()
	{
		yield return new WaitForSeconds(0.2f);
		glitch.enabled = true;
		yield return new WaitForSeconds(0.2f);
		glitch.enabled = false;
		StartCoroutine("erros");
	}

	IEnumerator	alterarSanidade()
	{
		yield return new WaitForSeconds(0.1f);
	
		pixelAmount += 0.03f;
		insanidade += 0.3f; // aumenta o grain
		if(pixelAmount >= 1)  // caso chegue no critico, o player morre
		{ 
			pixelAmount = 1; 
			fps.AcionarMorte();
            sumiu(); //
		}
		var temp = controle.grain.settings;
		temp.intensity = pixelAmount;
		controle.grain.settings = temp;
		if(pixelAmount < 1) // altera a sanidade
		{
			StartCoroutine("alterarSanidade");
		}
	}

	IEnumerator	reduzirInsanidade()
	{
		
		yield return new WaitForSeconds(0.1f);
		pixelAmount -= 0.1f;
        insanidade -= 0.2f;
        if (pixelAmount < 0) {
            pixelAmount = 0;
            insanidade = 0.1f;
        }
		var temp = controle.grain.settings;
		temp.intensity = pixelAmount;
		controle.grain.settings = temp;
		if(pixelAmount > 0)
		{
			StartCoroutine("reduzirInsanidade");
		}


	}

	public	void sumiu()
	{
		StopCoroutine("erros");
		StopCoroutine("alterarSanidade");
		glitch.enabled = false;
		StartCoroutine("reduzirInsanidade");
        
	}

}
