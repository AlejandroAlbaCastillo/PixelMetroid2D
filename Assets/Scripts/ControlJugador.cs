using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;
    public int puntuacion = 0;
    public int numVidas;
    public int tiempoNivel;
    public Canvas canvas;

    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private Animator animacion;
    private bool vulnerable;
    private float tiempoInicio;
    private int tiempoEmpleado;
    private ControlHUD hud;
    private ControlDatosJuego datosJuego;

    

    public AudioClip saltoSfx;
    public AudioClip vidaSfx;
    public AudioClip recolectarSfx;

    private AudioSource audioSource;
    // Start is called before the first frame update

    private void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
        tiempoInicio = Time.time;
        vulnerable = true;
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
        hud = canvas.GetComponent<ControlHUD>();
        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        datosJuego.Nivel=1;
        hud.SetVidasTxt(numVidas);
    }

    public void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad,
        fisica.velocity.y);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TocarSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto,
            ForceMode2D.Impulse);
            audioSource.PlayOneShot(saltoSfx);
        }

        if (fisica.velocity.x > 0) sprite.flipX = false;
        else if (fisica.velocity.x < 0) sprite.flipX = true;

        animarJugador();
        hud.SetPowerUpsTxt(GameObject.FindGameObjectsWithTag("PowerUp").Length);
        if(GameObject.FindGameObjectsWithTag("PowerUp").Length == 0) GanarJuego();
        
        tiempoEmpleado = (int)(Time.time - tiempoInicio);
        hud.SetTiempoTxt((int)(tiempoNivel-tiempoEmpleado));
        
        if(tiempoNivel-tiempoEmpleado<=0)FinJuego();
    }

    public void GanarJuego(){
        
        puntuacion = (numVidas*100)+(tiempoNivel - tiempoEmpleado);
        datosJuego.Puntuacion=puntuacion;
        datosJuego.Ganado =true;
        datosJuego.Vidas = numVidas;
        SceneManager.LoadScene("FinNivel");
    }
    public void IncrementarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        //Incrementa el valor de power up a la vida
        DarVida(cantidad);
    }

    private void animarJugador()
    {
        if (!TocarSuelo()) animacion.Play("jugadorSaltando");
        else if ((fisica.velocity.x > 1 || fisica.velocity.x < -1) && fisica.velocity.y == 0) animacion.Play("jugadorCorriendo");
        else if ((fisica.velocity.x < 1 || fisica.velocity.x > -1) && fisica.velocity.y == 0) animacion.Play("jugadorParado");

    }



    private bool TocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast
        (transform.position + new Vector3(0, -2f, 0),
        Vector2.down, 0.2f);
        return toca.collider != null;
    }

    public void FinJuego()
    {
        datosJuego.Ganado=false;
        datosJuego.Vidas = numVidas;//Se le da el numero de vidas conseguidas en el nivel para guardarlas para el siguiente
        SceneManager.LoadScene("FinNivel");
    }

//Metodo que añade la cantida de vida dada en el parametro
public void DarVida(int vida){
    numVidas+=vida;
    hud.SetVidasTxt(numVidas);
}
    public void QuitarVida(int danio)
    {

        if(vulnerable){
            vulnerable = false;
            numVidas-=danio;
            hud.SetVidasTxt(numVidas);
            if (numVidas <= 0) FinJuego();
            Invoke("HacerVulnerable",1f);
            sprite.color = Color.red;
            audioSource.PlayOneShot(vidaSfx);
        }

        

    }


    public void HacerVulnerable(){
        vulnerable = true;
        sprite.color = Color.white;
    }
}
