using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;
    private const float vidaMaxima = 5f; // vida maxima

    public void ModificarVida(float puntos)
    {
        vida += puntos;

        // Nos aseguramos que la vida no baje de cero
        if (vida < 0)
        {
            vida = 0;
            Debug.Log("Perdiste");
        }

        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }

        // Nos aseguramos que la vida no pase de cinco


        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }
}
