using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ControladorPuntaje : MonoBehaviour
{
	public static ControladorPuntaje Instancia { get; private set; }

	private ControladorHUDPuntaje controladorHUDPuntaje;
	[SerializeField] private int puntaje;
	[SerializeField] private int puntajeMaximo;
	[SerializeField] private UnityEvent<string> OnTextChanged;
	[SerializeField] private UnityEvent<string> OnTextmAXChanged;

	private void Awake()
	{
		if (Instancia == null) //Comprobamos no haya instancias previas
		{
			Instancia = this;
			DontDestroyOnLoad(gameObject); //Para conservar entre escenas
			puntaje = 0;

			// Borrar PlayerPrefs si es la primera vez que se ejecuta el build
			PrimerCarga();

			CargarProgresion(); //Carga el puntaje guardado
		}
		else
		{
			Destroy(gameObject); //Ya se creó, entonces se destruye
		}
	}

	private void Start()
	{
		controladorHUDPuntaje = FindObjectOfType<ControladorHUDPuntaje>();
		puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo");
		ActualizarHUD();
	}

	public void SumarPuntaje(int puntos)
	{
		puntaje += puntos;
		ActualizarHUD();

		if (puntaje > puntajeMaximo)
		{
			puntajeMaximo = puntaje;
			PlayerPrefs.SetInt("PuntajeMaximo", puntajeMaximo);
			PlayerPrefs.Save();
		}
	}

	public void RestaurarPuntaje()
	{
		puntaje = 0;
		ActualizarHUD();
	}

	public int GetPuntaje()
	{
		return puntaje;
	}

	public int GetPuntajeMaximo()
	{
		return puntajeMaximo;
	}

	private void ActualizarHUD()
	{
		if (controladorHUDPuntaje != null)
		{
			controladorHUDPuntaje.ActualizarTextoPuntaje(ControladorPuntaje.Instancia.GetPuntaje().ToString());
			OnTextChanged.Invoke(ControladorPuntaje.Instancia.GetPuntaje().ToString());

			controladorHUDPuntaje.ActualizarTextoPuntajeMaximo(ControladorPuntaje.Instancia.GetPuntajeMaximo().ToString());
			OnTextmAXChanged.Invoke(ControladorPuntaje.Instancia.GetPuntajeMaximo().ToString());
		}
	}

	private void OnApplicationQuit()
	{
		GuardarProgresion(); // Guarda el puntaje al salir de la aplicación
	}
	private void GuardarProgresion()
	{
		PlayerPrefs.SetInt("Puntaje", puntaje);
		PlayerPrefs.SetInt("PuntajeMaximo", puntajeMaximo);
		PlayerPrefs.Save();
	}
	private void CargarProgresion()
	{
		puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo", 0);
	}

	private void PrimerCarga()
	{
		if (PlayerPrefs.GetInt("PrimerCarga", 1) == 1)
		{
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("PrimerCarga", 0);
			PlayerPrefs.Save();
		}
	}
}
