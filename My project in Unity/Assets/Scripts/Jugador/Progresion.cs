using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    private Jugador jugador;

	private void OnEnable()
	{
		jugador = GetComponent<Jugador>();
	}
	private void SubirNivel(int numeroDeNivelJugador)
    {
		numeroDeNivelJugador++;
    }
}
