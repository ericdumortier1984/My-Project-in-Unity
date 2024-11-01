using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorHUD : MonoBehaviour
{
	
	[SerializeField] TextMeshProUGUI textoVida;
	//[SerializeField] TextMeshProUGUI mensajeTemporal;

   /* private void Start()
	{
		mensajeTemporal.gameObject.SetActive(false);
	}*/

	public void ActualizarTextoVida(string nuevoTextoVida)
	{
		textoVida.text = nuevoTextoVida;
	}

	/*public void MostrarMensajeTemporal(string textoTemporal)
	{
		StartCoroutine(MostrarMensajeTemporalCoroutine(textoTemporal));
	}

	private IEnumerator MostrarMensajeTemporalCoroutine(string textoTemporal)
	{
		mensajeTemporal.text = textoTemporal;
		mensajeTemporal.gameObject.SetActive(true);
		yield return new WaitForSeconds(2);
		mensajeTemporal.gameObject.SetActive(false);
	}*/
}
