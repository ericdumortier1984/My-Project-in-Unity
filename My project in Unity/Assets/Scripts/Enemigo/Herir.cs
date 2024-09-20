using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float puntos = 5f;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-puntos);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + puntos);
            collision.gameObject.GetComponent<Jugador>().HerirJugador(0, collision.GetContact(0).normal);
        }
    }
}