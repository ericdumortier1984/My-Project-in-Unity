using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarMonedas : MonoBehaviour
{
	[SerializeField]
	private PerfilJugador perfilJugador;
	public PerfilJugador PerfilJugador { get => perfilJugador; }

	public List<GameObject> monedas = new List<GameObject>();

	bool monedasRecolectadas = false;

	private Jugador jugador;
	private AudioSource miAudioSource;


	private void Start()
	{
		miAudioSource = GetComponent<AudioSource>();
		jugador = GetComponent<Jugador>();
		monedas.AddRange(GameObject.FindGameObjectsWithTag("monedas"));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("monedas")) { return; }

		RecogerMonedas(collision.gameObject);

	}

	private void Update()
	{
		if(!miAudioSource.isPlaying && monedasRecolectadas)
		{
			monedasRecolectadas = false;
		}
	}

	public void RecogerMonedas(GameObject monedaRecogida)
	{
		if (monedas.Contains(monedaRecogida))
		{
			monedas.Remove(monedaRecogida);
			monedaRecogida.SetActive(false); 
			miAudioSource.PlayOneShot(PerfilJugador.ItemSFX, PerfilJugador.VolumenItemSFX);
			ControladorPuntaje.Instancia.SumarPuntaje(10);

		}
	}
}
