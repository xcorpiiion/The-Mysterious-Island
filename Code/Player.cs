using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(Slider))]
public class Player : MonoBehaviour
{

    // barra de vida
    public float maxLife;
    public float currentLife;
    public Slider healtBar;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private bool walk = false;

    // receber lv
    public float xpCurrent = 0, xpMaximo = 0;
    public int lvAtual = 1, lvMaximo = 12;

    // Component caching
    private PlayerMotor motor;
    public Animator animator;

    public float horizontal;
    public float vertical;


    void Start()
    {
        lvAtual = PlayerPrefs.GetInt("lvAtual");
        // define o maximo de vida
        maxLife = PlayerPrefs.GetFloat("vidaPlayer");
        currentLife = maxLife;

        healtBar.value = calcularHealt();

        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>();

        ganharNivel();

    }

    void Update()
    {
        ganharNivel();

        

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (lvAtual < 1)
        {
            lvAtual = 1;
            PlayerPrefs.SetFloat("vidaPlayer", 100);
        }
        else if (lvAtual > 12)
        {
            lvAtual = 12;
        }

        //Calculate movement velocity as a 3D vector
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);

        // verifica se pode ativar a animação
        if (vertical > 0) {
            walk = true;
        } else if(vertical < 0) {
            walk = true;
        } else {
            walk = false;
        }
        
        //Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);

        animator.SetBool("Andando", walk);

    }

    // aplica dano
    public void danoPlayer(float damageValue)
    {
        currentLife -= damageValue;
        healtBar.value = calcularHealt();
        if (currentLife <= 0) {
            die();

        }

    }

    private float calcularHealt() {

        return currentLife / maxLife;
    }

    // personagem morreu
    private void die() {
        currentLife = 0;
    }

    private void ganharNivel()
    {
        switch (PlayerPrefs.GetInt("lvAtual"))
        {
            case 1:
                PlayerPrefs.SetFloat("vidaPlayer", 100);
                xpMaximo = 1000.0f;
                PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 2000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                    
                }
                break;
            case 2:
                PlayerPrefs.SetFloat("vidaPlayer", 300);
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 3000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 3:
                PlayerPrefs.SetFloat("vidaPlayer", 500);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    
                    xpMaximo = 4000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }

                break;
            case 4:
                PlayerPrefs.SetFloat("vidaPlayer", 700);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 5000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 5:
                PlayerPrefs.SetFloat("vidaPlayer", 900);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 6000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 6:
                PlayerPrefs.SetFloat("vidaPlayer", 1000);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 7000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 7:
                PlayerPrefs.SetFloat("vidaPlayer", 1100);
               
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 8000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 8:
                PlayerPrefs.SetFloat("vidaPlayer", 1300);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 9000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 9:
                PlayerPrefs.SetFloat("vidaPlayer", 1400);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 10000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 10:
                PlayerPrefs.SetFloat("vidaPlayer", 1500);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 10000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 11:
                PlayerPrefs.SetFloat("vidaPlayer", 1600);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    lvAtual += 1;
                    PlayerPrefs.SetInt("lvAtual", lvAtual);
                    xpMaximo = 12000.0f;
                    PlayerPrefs.SetFloat("xpMaximo", xpMaximo);
                    
                }
                break;
            case 12:
                PlayerPrefs.SetFloat("vidaPlayer", 1700);
                
                if (xpCurrent >= xpMaximo)
                {
                    PlayerPrefs.SetFloat("xpAtual", xpCurrent - xpMaximo);
                    PlayerPrefs.SetInt("lvAtual", 12);
                    
                }
                break;
        }
    }
    // fim do atualizar xp
    //*************************************************************************************


}