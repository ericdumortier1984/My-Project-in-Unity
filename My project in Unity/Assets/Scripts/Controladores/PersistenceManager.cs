using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistenceManager : MonoBehaviour
{
	public Slider barraSonido;
	public Slider barraBrillo;
	public float valorBarraSonido;
	public float intensidadBrillo;
	public Image imagenMuteado;
	public Image imagenSinBrillo;

	void Start()
	{
		barraSonido.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
		AudioListener.volume = barraSonido.value;
		Muteado();

		barraBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
		imagenSinBrillo.color = new Color(imagenSinBrillo.color.r, imagenSinBrillo.color.g, imagenSinBrillo.color.b, barraBrillo.value);
	}

	public void ManejarVolumen(float valor)
	{
		valorBarraSonido = valor;
		PlayerPrefs.SetFloat("volumenAudio", valorBarraSonido);
		AudioListener.volume = barraSonido.value;
		Muteado();
	}

	public void ManejarBrillo(float valor)
	{
		intensidadBrillo= valor;
		PlayerPrefs.SetFloat("brillo", intensidadBrillo);
		imagenSinBrillo.color = new Color(imagenSinBrillo.color.r, imagenSinBrillo.color.g, imagenSinBrillo.color.b, barraBrillo.value);
	}

	private void Muteado()
	{
		if (valorBarraSonido == 0)
		{
			imagenMuteado.enabled = true;
		}
		else
		{
			imagenMuteado.enabled = false;
		}

	}
}