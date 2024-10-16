using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorHUD : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI textoVida;

	public void ActualizarTextoVida(string nuevoTextoVida)
	{
		textoVida.text = nuevoTextoVida;
	}
}
