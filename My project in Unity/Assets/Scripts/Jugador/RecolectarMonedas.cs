using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarMonedas : MonoBehaviour
{
	[SerializeField] private PerfilJugador perfilJugador;
	[SerializeField] private ParticleSystem particulaRecoleccionMoneda;
	public PerfilJugador PerfilJugador { get => perfilJugador; }
	public List<GameObject> monedas = new List<GameObject>();
	private Jugador jugador;
	private AudioSource miAudioSource;
	bool monedasRecolectadas = false;


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
			monedaRecogida.SetActive(false);
			// Reproduce el sistema de partículas en la posición de la moneda recogida
			particulaRecoleccionMoneda.transform.position = monedaRecogida.transform.position;
			particulaRecoleccionMoneda.Play();
			miAudioSource.PlayOneShot(PerfilJugador.ItemSFX, PerfilJugador.VolumenItemSFX);
			ControladorPuntaje.Instancia.SumarPuntaje(50);

		}
	}
}
