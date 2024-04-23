using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDatosJuego : MonoBehaviour
{


    private int puntuacion;
    private bool ganado;
    private int vidas;

    private int nivel;
   
   public int Puntuacion { get=> puntuacion; set => puntuacion = value; }
   public bool Ganado { get=> ganado; set => ganado = value; }
   public int Vidas { get=> vidas; set => vidas = value; }

   public int Nivel { get=> nivel; set => nivel = value; }

   private void Awake(){
    int numInstancias = FindObjectsOfType<ControlDatosJuego>().Length;

    if (numInstancias != 1)
    {
        Destroy(this.gameObject);
    }
    else{
        DontDestroyOnLoad(this.gameObject);
    }
   }

   public void SubirNivel(){
    nivel++;
   }
}
