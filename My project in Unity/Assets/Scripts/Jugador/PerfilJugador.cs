using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
	[Header("Configuraciones de experiencia")]
	[SerializeField] // nivel
	[Range(0, 100)] private int nivel;
	public int Nivel { get => nivel; set => nivel = value; }


	[SerializeField] // nivel inicial
	[Range(0, 100)] private int nivelInicial;

	[Header("Configuraciones de movimiento")]
	[SerializeField] // fueerza salto
	[Range(0, 10)] private float fuerzaSalto;
	public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value; }

	[SerializeField] // velocidad
	[Range(0, 10)] private float velocidad;
	public float Velocidad { get => velocidad; set => velocidad = value; }

	[SerializeField] // opciones de salto
	[Range(0, 5)] private float multiplicadorCaida;
	public float MultiplicadorCaida { get => multiplicadorCaida; set => multiplicadorCaida = value; }

	[SerializeField]
	[Range(0, 5)] private float multiplicadorSaltoBajo;
	public float MultiplicadorSaltoBajo { get => multiplicadorSaltoBajo; set => multiplicadorSaltoBajo = value; }

	[SerializeField] // inactividad por colision
	[Range(0, 5)] private float inactividadPorColision;
	public float InactividadPorColision { get => inactividadPorColision; set => inactividadPorColision = value; }

	[Header("Configuraciones de Atributos")]
	[SerializeField] // vida
	[Range(0, 5)] private int vida;
	public int Vida { get => vida; set => vida = value; }

	[SerializeField] // vida maxima
	[Range(4, 10)] private int vidaMaxima;
	public int VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }

	[SerializeField]
	[Range(0, 5)] private int vidaInicial;

	public void ReiniciarValores()
	{
		nivel = nivelInicial;
		vida = vidaInicial;
	}

	[Header("Configuraciones SFX")]
	[SerializeField] // Salto
	private AudioClip jumpSFX;
	public AudioClip JumpSFX { get => jumpSFX; set => jumpSFX = value; }

	[SerializeField]
	[Range(0, 5)] private float volumenSaltoSFX;
	public float VolumenSaltoSFX { get => volumenSaltoSFX; set => volumenSaltoSFX = value; }

	[SerializeField] // Monedas
	private AudioClip itemSFX;
	public AudioClip ItemSFX { get => itemSFX; set => itemSFX = value; }

	[SerializeField]
	[Range(0, 5)] private float volumenItemSFX;
	public float VolumenItemSFX { get => volumenItemSFX; set => volumenItemSFX = value; }

	[SerializeField] // Diamante
	private AudioClip diamanteSFX;
	public AudioClip DiamanteSFX { get => diamanteSFX; set => diamanteSFX = value; }

	[SerializeField]
	[Range(0, 5)] private float volumenDiamanteSFX;
	public float VolumenDiamanteSFX { get => volumenDiamanteSFX; set => volumenDiamanteSFX = value; }

	[SerializeField] // golpe enemigo
	private AudioClip golpeEnemigoSFX;
	public AudioClip GolpeEnemigoSFX { get => golpeEnemigoSFX; set => golpeEnemigoSFX = value; }

	[SerializeField]
	[Range(0, 5)] private float volumenGolpeEnemigoSFX;
	public float VolumenGolpeEnemigoSFX { get => volumenGolpeEnemigoSFX; set => volumenGolpeEnemigoSFX = value; }
}
