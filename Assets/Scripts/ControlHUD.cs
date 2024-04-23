using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHUD : MonoBehaviour
{

    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI tiempoTxt;
    public TextMeshProUGUI powerUpsTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void SetVidasTxt(int vidas){
    vidasTxt.text = "Vidas : "+vidas;
}
public void SetTiempoTxt(int tiempo){
    int segundos = tiempo % 60;
    int minutos = tiempo / 60;

    tiempoTxt.text = minutos.ToString("00") +" : "+segundos.ToString("00");
}

public void SetPowerUpsTxt(int cuantos){
    powerUpsTxt.text = "Objetos : "+cuantos;
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
