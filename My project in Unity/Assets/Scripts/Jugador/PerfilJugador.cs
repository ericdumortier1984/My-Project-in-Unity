using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
	[Header("Configuraciones de experiencia")]
	[SerializeField]
	[Range(0, 100)] private int nivel;
	public int Nivel { get => nivel; set => nivel = value; }

	[Header("Configuraciones de movimiento")]
	[SerializeField]
	[Range(0, 10)] private float fuerzaSalto;
	public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value; }

	[SerializeField]
	[Range(0, 10)] private float velocidad;
	public float Velocidad { get => velocidad; set => velocidad = value; }

	[SerializeField]
	[Range(0, 5)] private float multiplicadorCaida;
	public float MultiplicadorCaida { get => multiplicadorCaida; set => multiplicadorCaida = value; }

	[SerializeField]
	[Range(0, 5)] private float multiplicadorSaltoBajo;
	public float MultiplicadorSaltoBajo { get => multiplicadorSaltoBajo; set => multiplicadorSaltoBajo = value; }

	[SerializeField]
	[Range(0, 5)] private float inactividadPorColision;
	public float InactividadPorColision { get => inactividadPorColision; set => inactividadPorColision = value; }

	[Header("Configuraciones de Atributos")]
	[SerializeField]
	[Range(0, 5)] private int vida;
	public int Vida { get => vida; set => vida = value; }

	[SerializeField]
	[Range(5, 10)] private int vidaMaxima;
	public int VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }

	[Header("Configuraciones SFX")]
	[SerializeField]
	private AudioClip jumpSFX;
	public AudioClip JumpSFX { get => jumpSFX; set => jumpSFX = value; }

	[SerializeField]
	[Range(0, 5)] private float volumenSaltoSFX;
	public float VolumenSaltoSFX { get => volumenSaltoSFX; set => volumenSaltoSFX = value; }   

	[SerializeField]
	private AudioClip diamanteSFX;
	public AudioClip DiamanteSFX { get => diamanteSFX; set => diamanteSFX = value; }
	
	[SerializeField]
	[Range(0, 5)] private float volumenDiamanteSFX;
	public float VolumenDiamanteSFX { get => volumenDiamanteSFX; set => volumenDiamanteSFX = value; }

}
