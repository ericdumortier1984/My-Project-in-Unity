using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistenceManager : MonoBehaviour
{
	public Slider barraSonido;
	public float valorBarraSonido;
	public Image imagenMuteado;

	void Start()
	{
		barraSonido.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
		AudioListener.volume = barraSonido.value;
		Muteado();
	}

	public void ManejarVolumen(float valor)
	{
		valorBarraSonido = valor;
		PlayerPrefs.SetFloat("volumenAudio", valorBarraSonido);
		AudioListener.volume = barraSonido.value;
		Muteado();
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