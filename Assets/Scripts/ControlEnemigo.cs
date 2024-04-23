using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;

    private Vector3 posicionInicio;
    private bool moviendoAFin;
    public int danio;
    private float tiempoInicio;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo(){
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;

        transform.position = Vector3.MoveTowards(
            transform.position, posicionDestino, velocidad * Time.deltaTime
        );

        if (transform.position == posicionFin) moviendoAFin = false;
        if (transform.position == posicionInicio) moviendoAFin = true;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<ControlJugador>().QuitarVida(danio);
        }
    }
}
