using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]

public class FpsController : MonoBehaviour {

    
    public GameController gameController;
    public GameObject cameraFps, cameraMorte;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    [Space(2)]
    [Header("Cuida da velocidade")]
    public float moveSpeed, speedCam, jumpForce, baseSpeed, incremmentSpeed;
    private float rotationX, rotationY;
    [Space(2)]
    [Header("Objeto que eu estou interagindo")]
    public GameObject interaction;
    
    private bool  corrida = false;

    private AudioSource audioS;
    [Space(1)]
    [Header("Cuida dos audios")]
    public AudioClip[] audioStep;
    public AudioClip jumpSound, landSound; // som ou pular e tocar no chão
    public AudioClip grito;
    [Space(2)]
    [Header("Determina o valor do tempo do passo")]
    public float delayPassos; // tempo entre um passo e outro
    public float timePassos; // irá armazenar o tempo decorrido após o passo dado
    private float factorDelay = 1; // multiplicador que irá alterar o tempo de espera entre os passos
    private bool inAir = false; // indica que o player está no ar
    public float distanceInterection;
    public Sprite[] imgInteractions;
    public Image curso;

    /// </Controle de animação/>
    [Space(2)]
    [Header("Cuida da animação da Clara")]
    public Animator anim;
    public int idAnimation;
    public Transform cotovelo;

    /// </summary>

    [Space(2)]
    [Header("Cuida do texto")]
    public TMP_Text txtInteracao;
    public bool exibirMensagem; // será ativado ao exibir mensagem de uso do item
    [Header("Tempo de espera das mensagens")]
    public float temEspera; // tempo que a mensagem ficara ativa na tela

    public bool usarGasolina, usouGasolina; // permissão para usar a gasolina
    public bool usouBateria, usarBateria, usouAlavanca; /// permissão para ligar o Terminal
    public bool usouAlcool, usarAlcool, usouIsqueiro;
    public bool usouPilha, usarPilha, usouIPilha;
    public bool usouSinalizador, usarSinalizador, usouISinalizador;
    public bool usarRosa; // usa a rosa
    public GameObject[] rosas;
    public string nomeTumba;
    public bool[] usandoRosa;
    public string idTumba = ""; // tem os id da tumba

    public GameObject clara;
    
    // responsavel pela lanterna
    [Space(3)]
    [Header("Responsavel pela lanterna")]
    [Header("Armazena a quantidade de carga que a bateria pode ter")]
    [Range(0, 100)]
    public byte maxCarga; // armazena o maximo que a bateria pode ter
    public float carga; // armazena a carga da bateria
    [Space(5)]
    [Header("Quantidade de carga gasta a cada segundo")]
    [Range(0, 30)]
    public float gastarCarga, time, timeCamera /* // controla o tempo de maneira manual */; // quantidade de carga gasta
    private byte tempoLanterna = 2;
    public bool ligar = false;
    public Light lanterna;
    public float intensidade;
    public Image energyBar; // representação grafica da barra de energia da Flashlight
    private float porcentagemBattery; // porcentagem da bateria
    public AudioClip playSound;
    public GameObject luzAux;

    // responsavel pelo efeito da camera

    [Space(3)]
    [Header("Responsavel pela Camera")]
    public GameObject hudCam;
    [Header("Armazena a quantidade de carga que a bateria pode ter")]
    [Range(0, 100)]
    public byte maxCargaCamera; // armazena o maximo que a bateria pode ter
    public float cargaCamera; // armazena a carga da bateria
    [Space(5)]
    [Header("Quantidade de carga gasta a cada segundo")]
    [Range(0, 30)]
    public float gastarCargaCamera /* // controla o tempo de maneira manual */; // quantidade de carga gasta
    private byte tempoBattery = 2;
    public bool ligarCamera = false;
    public Image energyBarCamera; // representação grafica da barra de energia da Flashlight
    private float porcentagemBatteryCamera; // porcentagem da bateria
    
    public byte cutSceneCemiterio = 0;
    public GameObject seeCriature;
    // fim efeito camera

    [Header("Som do item ao interagir")]
    // som ao interagir com item
    public AudioClip itemSound, arquivoSound;

    // pega a posição do respawn do player
    public GameObject msg;

    private Scene cena;

    private bool mostrarMsg = false;

    [Space(2)]
    [Header("Mostra os comandos")]
    public GameObject movimentos, ativarCamera, pegarItens;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {

        luzAux.SetActive(false);
        transform.position = new Vector3(63.96f, 28.41f, -185.19f);

        seeCriature.SetActive(false);

        msg.SetActive(false);

        for(int i = 0; i < rosas.Length; i++) {
            rosas[i].SetActive(false);
        }

        pegarItens.SetActive(false);
        ativarCamera.SetActive(false);
        movimentos.SetActive(false);

        curso.sprite = imgInteractions[0];
        
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        audioS = GetComponent<AudioSource>();

        transform.tag = "Player";
        
        controller = GetComponent<CharacterController>();

        cameraFps.transform.localRotation = Quaternion.identity;
        cameraMorte.SetActive(false);

        moveSpeed = baseSpeed;
        

        ////// Lanterna
        carga = maxCarga;
        lanterna.intensity = intensidade;
        lanterna.enabled = ligar;
        // fim lanterna

        // efeito da camera
        cargaCamera = maxCargaCamera;
        hudCam.SetActive(ligarCamera);


        // fim do efeito da camera
    

    }
	
	// Update is called once per frame
	void Update () {
        

        if(gameController.currentState != GameState.GAMEPLAY) {
            curso.gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        } else {
            curso.gameObject.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
        }


        // responsavel pela lanterna
        flashLight();
        // fim da lanterna

        // responsavel pelo efeito da camera
        efeitoCamera();
        // fim do efeito da camera

        Vector3 directionFront = new Vector3(cameraFps.transform.forward.x, 0, cameraFps.transform.forward.z);


        directionFront *= Input.GetAxis("Vertical");

        directionFront.Normalize();


        Vector3 directionRight = new Vector3(cameraFps.transform.right.x, 0, cameraFps.transform.right.z);

        directionRight *= Input.GetAxis("Horizontal");


        Vector3 directionFinal = directionFront + directionRight;
        
        // controla a movimentação
        if (controller.isGrounded){
            ;
            if (inAir) {
                inAir = false;
                audioS.PlayOneShot(landSound);
                idAnimation = 0;
            } else {
                if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
                    if (corrida)
                    {
                        idAnimation = 2;
                    } else {
                        idAnimation = 1;
                    }
                } else {
                    idAnimation = 0;
                }
            }

            moveDirection = new Vector3(directionFinal.x, 0, directionFinal.z) * moveSpeed;
            if(Input.GetButtonDown("Jump")) {
                moveDirection.y = jumpForce;
                audioS.PlayOneShot(jumpSound);
                inAir = true;
                idAnimation = 3;
            }

            
            
        }

        

        if (Input.GetButtonDown("Correr")) {
            moveSpeed = baseSpeed + incremmentSpeed;
            corrida = true;
        }

        if(Input.GetButtonUp("Correr")) {
            moveSpeed = baseSpeed;
            corrida = false;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        MyCamController();

        RaycastHit hit;
        if(Physics.Raycast(cameraFps.transform.position, cameraFps.transform.forward, out hit, distanceInterection)) {
            if(hit.transform.gameObject.tag == "Interacao" || hit.transform.gameObject.tag == "Door" || hit.transform.gameObject.tag == "Coletavel" 
                || hit.transform.gameObject.tag == "Arquivos" || hit.transform.gameObject.tag == "Rosa") {
                interaction = hit.transform.gameObject;
                curso.sprite = imgInteractions[1];
                pegarItens.SetActive(true);
                if(!exibirMensagem)
                    txtInteracao.text = hit.collider.gameObject.GetComponent<MsgInteracao>().messenger;

                // verifica se eu estou colidindo com a tumba
                if (hit.collider.gameObject.name == "Tumba" || hit.collider.gameObject.name == "Tumba01" || hit.collider.gameObject.name == "Tumba02" ||
                        hit.collider.gameObject.name == "Tumba03" || hit.collider.gameObject.name == "Tumba04")
                {
                    
                    nomeTumba = interaction.name; // pega o nome da tumba
                    usarRosa = true; // serve para eu poder usar a rosa com o botão usar;
                }

                if (hit.collider.gameObject.name == "Gerador")
                {
                    usarGasolina = true;
                }

                if (hit.collider.gameObject.name == "InteracaoTerminal")
                {
                    usarBateria = true;
                }

                if (hit.collider.gameObject.name == "Cristine Esqueleto")
                {
                    usarAlcool = true;

                }

                if (hit.collider.gameObject.name == "Radio")
                {
                    usarPilha = true;

                }

                if (hit.collider.gameObject.name == "Encaixar Sinalizador")
                {
                    usarSinalizador = true;

                }

                if (hit.collider.gameObject.name == "EPo")
                {
                    usarSinalizador = true;

                }

                if (Input.GetButtonDown("Left Mouse") && interaction != null) {
                                        
                    if(!mostrarMsg) {
                        msg.SetActive(true);
                        StartCoroutine("esperarMsg");
                        mostrarMsg = true;
                    }



                    // verifica se o objeto que eu estou colidindo tem a tag coletavel
                    if (hit.collider.gameObject.tag == "Coletavel") {
                        audioS.clip = itemSound;
                        audioS.Play();
                        if(hit.collider.gameObject.name == "Sport Camera dae") {
                            if (gameController.chave.Count < gameController.slot.Length)
                            {
                                
                                ativarCamera.SetActive(true);
                                StartCoroutine("mostrarTecla");
                            }
                        }

                        if (hit.collider.gameObject.name == "Chave do Papai") { // verifica se o objeto que eu colidi tem o nome battery
                            SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                            if (valve.resolvido) // verifica se eu resolvi o puzzle das valvulas
                            {
                                if (gameController.chave.Count < gameController.slot.Length)
                                {
                                    gameController.chave.Add(interaction);
                                    interaction.SendMessage("interacao");
                                }
                            } else { // se eu não tiver resolvido o puzzle aparece está mensagem
                                exibirMensagemItem("Desligue a luz para poder pegar");
                            }
                        }  else { // se eu não estiver colidindo com a bateria, eu pego o coletavel normalmente
                            if (gameController.chave.Count < gameController.slot.Length) {
                                gameController.chave.Add(interaction);
                                interaction.SendMessage("interacao");
                            }
                        }

                    } else if(hit.collider.gameObject.tag == "Arquivos") {
                        audioS.clip = arquivoSound;
                        audioS.Play();
                        if (hit.collider.gameObject.name == "Carta do pai")
                        {
                            SystemValve valve = FindObjectOfType(typeof(SystemValve)) as SystemValve;
                            if (valve.resolvido)
                            {
                                if (gameController.arquivos.Count < gameController.slotArquivos.Length)
                                {
                                    gameController.arquivos.Add(interaction);
                                    interaction.SendMessage("interacao");
                                }
                            } else {
                                exibirMensagemItem("Desligue a luz para poder pegar");
                            }
                        } else  {
                            if (gameController.arquivos.Count < gameController.slotArquivos.Length)
                            {
                                gameController.arquivos.Add(interaction);
                                interaction.SendMessage("interacao");
                            }
                        }
                    } else if (hit.collider.gameObject.tag == "Rosa")  {
                        audioS.clip = itemSound;
                        audioS.Play();
                        if (gameController.chave.Count < gameController.slot.Length)
                        {
                            gameController.chave.Add(interaction);
                            interaction.SendMessage("interacao");
                        }
                        usandoRosa[0] = false;
                        usandoRosa[1] = false;
                        usandoRosa[2] = false;
                        usandoRosa[3] = false;
                        usarRosa = true;
                    } else {
                        interaction.SendMessage("interacao");
                    }

                    

                }
                
            } else {
                curso.sprite = imgInteractions[0];
                pegarItens.SetActive(false);
                txtInteracao.text = null;
                exibirMensagem = false;
                StopCoroutine("esperarMensagem");
                usarGasolina = false;
                usarPilha = false;
                usarAlcool = false;
                usarBateria = false;
                usarSinalizador = false;
                nomeTumba = null;
                interaction = null;
            }
            
        } else {
            curso.sprite = imgInteractions[0];
            pegarItens.SetActive(false);
            txtInteracao.text = null;
            exibirMensagem = false;
            nomeTumba = null;
            StopCoroutine("esperarMensagem");
            interaction = null;
        }


        anim.SetInteger("idAnimation", idAnimation);
        
    }

    private void MyCamController() {
        rotationX += Input.GetAxis("Mouse X") * speedCam;
        rotationX = clampAngle(rotationX, -360, 360);


        rotationY += Input.GetAxis("Mouse Y") * speedCam;
        rotationY = clampAngle(rotationY, -80, 80);

        Quaternion xQuat = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(rotationY, -Vector3.right);
        

        cameraFps.transform.localRotation = yQuat;
        clara.transform.localRotation = xQuat;

        if(ligar) { // controla o braço com o mouse
            cotovelo.localRotation = Quaternion.AngleAxis(rotationY + 80, new Vector3(1, 0, 1));

        } else {
            cotovelo.localRotation = Quaternion.Euler(19.2F, 64.2F, 14.6F);
            
        }
    }

    private float clampAngle(float angle, float min, float max) {
        if(angle < -360) {
            angle += 360;
        }

        if(angle > 360) {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }


    public void exibirMensagemItem(string mensagem) {
        txtInteracao.text = mensagem;
        exibirMensagem = true;
        StartCoroutine("esperarMensagem");
    }


    IEnumerator esperarMsg()
    {
        
        yield return new WaitForSeconds(7);
        msg.SetActive(false);
    }

    IEnumerator esperarMensagem() {
        yield return new WaitForSeconds(temEspera);
        exibirMensagem = false;
    }

    IEnumerator mostrarTecla()
    {
        yield return new WaitForSeconds(7);
        ativarCamera.SetActive(false);
    }

    public void AcionarMorte() {
        CutScene cutScene = FindObjectOfType(typeof(CutScene)) as CutScene;
        cutScene.cena10();
        
    }

    

    /// <Lanterna>
    private void flashLight()
    {
        if (Input.GetButtonDown("Right Mouse") && carga > 0)
        {
            audioS.clip = playSound;
            audioS.Play();
            ligar = !ligar;
            lanterna.enabled = ligar;
            luzAux.SetActive(ligar);
            
        }

        if (carga <= maxCarga / 2)
        {
            lanterna.intensity = intensidade / 2;
        }
        else
        {
            lanterna.intensity = intensidade;
        }

        if (ligar)
        {
            usarLanterna();
        }
        else
        {
            lanterna.enabled = false;
            time = 0;
        }

        // atualiza a energia da lanterna
        updateEnergyBar();
    }


    // controla o tempo de maneira manual
    private void tempo()
    {
        time -= Time.deltaTime;

    }

    private void tempoCam()
    {
        timeCamera -= Time.deltaTime;

    }

    // usa a lanterna
    private void usarLanterna()
    {
        if (ligar)
        {

            if (time <= 0)
            {
                carga -= gastarCarga;
                time = tempoLanterna;
            }
            else
            {
                tempo();
            }

            if (carga < 0)
            {
                carga = 0;
                lanterna.enabled = false;
                ligar = false;
            }

        }
    }

    public void recarregar(float qtdCarga)
    {
        carga += qtdCarga;
        if (carga > maxCarga)
        {
            carga = maxCarga;
        }
    }

    private void updateEnergyBar()
    {
        porcentagemBattery = carga / maxCarga;
        if (porcentagemBattery > 1)
        {
            porcentagemBattery = 1;
        }
        else if (porcentagemBattery < 0)
        {
            porcentagemBattery = 0;
        }

        energyBar.transform.localScale = new Vector3(porcentagemBattery, 1, 1);

    }

    /// </fim Lanterna>

    /// responsavel pelo efeito da camera
    private void efeitoCamera()
    {
        foreach (GameObject item in gameController.chave)
        {
            if (item.GetComponent<ItemInfo>().nomeItem == "Camera")
            {
                if (Input.GetButtonDown("Middle Mouse") && cargaCamera > 0)
                {
                    ligarCamera = !ligarCamera;
                    hudCam.SetActive(ligarCamera);
                    seeCriature.SetActive(ligarCamera);

                }
            }


            if (cargaCamera <= 0) {
                hudCam.SetActive(false);
                cargaCamera = 0;
            }

            if (ligarCamera)
            {
                usarCamera();
            }
            else
            {
                timeCamera = 0;
            }

            // atualiza a energia da lanterna
            updateEnergyBarCamera();

        }
    }

        // usa a lanterna
        void usarCamera()
        {
            if (ligarCamera)
            {

                if (timeCamera <= 0)
                {
                    cargaCamera -= gastarCargaCamera;
                    timeCamera = tempoBattery;
                }
                else
                {
                    tempoCam();
                }

                if (cargaCamera < 0)
                {
                    cargaCamera = 0;
                    ligarCamera = false;
                }

            }
        }

        public void recarregarCamera(float qtdCarga)
        {
            cargaCamera += qtdCarga;
            if (cargaCamera > maxCargaCamera)
            {
                cargaCamera = maxCargaCamera;
            }
        }

         void updateEnergyBarCamera()
        {
        porcentagemBatteryCamera = cargaCamera / maxCargaCamera;
            if (porcentagemBatteryCamera > 1)
            {
            porcentagemBatteryCamera = 1;
            }
            else if (porcentagemBatteryCamera < 0)
            {
            porcentagemBatteryCamera = 0;
            }

            energyBarCamera.transform.localScale = new Vector3(porcentagemBatteryCamera, 1, 1);

        }


    /// fim do efeito da camera

    


}
