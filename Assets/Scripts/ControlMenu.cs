using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    
    private ControlFinNivel control;
private int cfn;
    
    
public void OnBotonJugar(){
    SceneManager.LoadScene("Nivel1");
}

public void OnBotonCreditos(){
    SceneManager.LoadScene("Creditos");
}

public void OnBotonMenu(){
    SceneManager.LoadScene("Menu");
}

public void OnBotonSalir(){
    Application.Quit();
}



}
