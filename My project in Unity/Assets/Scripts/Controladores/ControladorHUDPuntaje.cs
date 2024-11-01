using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorHUDPuntaje : MonoBehaviour
{
	public static ControladorHUD Instancia { get; private set; }
	[SerializeField] TextMeshProUGUI textoPuntaje;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void ActualizarTextoPuntaje(string nuevoTextoPuntaje)
	{
		textoPuntaje.text = nuevoTextoPuntaje;
	}
}
