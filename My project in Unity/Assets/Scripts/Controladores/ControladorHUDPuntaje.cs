using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorHUDPuntaje : MonoBehaviour
{
	public static ControladorHUDPuntaje Instancia { get; private set; }
	[SerializeField] TextMeshProUGUI textoPuntaje;
	[SerializeField] TextMeshProUGUI textoPuntajeMaximo;

	private void Awake()
	{
		if (Instancia == null) 
		{ 
			Instancia = this; 
			DontDestroyOnLoad(gameObject); 
		} 
		else 
		{ 
			Destroy(gameObject);
		}
	}

	public void ActualizarTextoPuntaje(string nuevoTextoPuntaje)
	{
		textoPuntaje.text = "SCORE: " + nuevoTextoPuntaje;
	}

	public void ActualizarTextoPuntajeMaximo(string nuevoTextoPuntajeMaximo)
	{
		textoPuntajeMaximo.text = "HIGH SCORE: " + nuevoTextoPuntajeMaximo;
	}
}
