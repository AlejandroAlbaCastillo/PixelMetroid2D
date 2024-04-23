using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ControlFinNivel : MonoBehaviour
{
    public TextMeshProUGUI mensajeFinalTexto;
    public TextMeshProUGUI vidasMensaje;
    private ControlDatosJuego datosJuego;
    public Button siguiente;
    public TextMeshProUGUI  nextLevel;
    
    public int nivel;
    
    // Start is called before the first frame update
    void Start()
    {
        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        string mensajeFinal = (datosJuego.Ganado) ? "Ha ganado" : "Ha perdido";

        if (datosJuego.Ganado) mensajeFinal += "Puntuacion: " + datosJuego.Puntuacion;

        mensajeFinalTexto.text = mensajeFinal;

        vidasMensaje.text = (datosJuego.Vidas<=0) ? " ":"Vidas: "+datosJuego.Vidas;
        datosJuego.Nivel++;
        nivel = datosJuego.Nivel;
        nextLevel.text = datosJuego.Nivel+"";

        if (!datosJuego.Ganado)
        {
        //    siguiente.interactable = false;
           siguiente.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBotonSiguiente(){
        if (datosJuego.Nivel==2)
        {
            SceneManager.LoadScene("Nivel"+datosJuego.Nivel);
           datosJuego.SubirNivel();
        }else{
            SceneManager.LoadScene("Nivel3");
        }
    
}
}
