using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ControlPowerUp : MonoBehaviour
{
    public int cantidad;
    
    public AudioClip recolectarSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<AudioSource>().PlayOneShot(recolectarSfx);
            collision.gameObject.GetComponent<ControlJugador>().IncrementarPuntos(cantidad);
            Destroy(gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
