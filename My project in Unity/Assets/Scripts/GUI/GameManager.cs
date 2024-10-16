using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PerfilJugador perfilJugador;
	[SerializeField] private GameObject menuPausa;
	[SerializeField] private GameObject menuVictoria;
	[SerializeField] private GameObject menuDerrota;

	private bool esPausa = false;

	private void OnEnable()
	{
		GameEvents.OnPausa += ModoPausa;
		GameEvents.OnResumen += ModoResumen;
		GameEvents.OnVictoria += ModoVictoria;
		GameEvents.OnDerrota += ModoDerrota;
	}

	private void OnDisable()
	{
		GameEvents.OnPausa -= ModoPausa;
		GameEvents.OnResumen -= ModoResumen;
		GameEvents.OnVictoria -= ModoVictoria;
		GameEvents.OnDerrota -= ModoDerrota;
	}

	private void Start()
	{
		menuPausa.SetActive(false);
		menuVictoria.SetActive(false);
		menuDerrota.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (esPausa)
			{
				GameEvents.TriggerResumen();
			}
			else
			{
				GameEvents.TriggerPausa();
			}
		}
	}

	private void ModoPausa()
	{
		esPausa = true;
		Time.timeScale = 0f;
		menuPausa.SetActive(true);
	}

	private void ModoResumen()
	{
		esPausa = false;
		Time.timeScale = 1f;
		menuPausa.SetActive(false);
	}

	private void ModoDerrota()
	{
		Time.timeScale = 1f;
		menuDerrota.SetActive(true);
		Invoke("VolverAlMenuPrincipal", 5f);
		perfilJugador.ReiniciarValores();
	}

	private void ModoVictoria()
	{
		Time.timeScale = 1f;
		menuVictoria.SetActive(true);
		Invoke("VolverAlMenuPrincipal", 5f);
		perfilJugador.ReiniciarValores();
	}

	private void VolverAlMenuPrincipal()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
