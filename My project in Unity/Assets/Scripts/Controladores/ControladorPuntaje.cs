using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ControladorPuntaje : MonoBehaviour
{
    public static ControladorPuntaje Instancia { get; private set; }
	private ControladorHUDPuntaje controladorHUDPuntaje;
	//private ControladorHUD controladorHUD;
	[SerializeField] private UnityEvent<string> OnTextChanged;
	private int puntaje;

	private void Awake()
	{
		if (Instancia == null) //Comprobamos no haya instancias previas
		{
			Instancia = this;
			DontDestroyOnLoad(gameObject); //Para conservar entre escenas
			puntaje = 0;
		}
		else 
		{
			Destroy(gameObject); //Ya se creó, entonces se destruye
		}
	}

	private void Start()
	{
		controladorHUDPuntaje = FindObjectOfType<ControladorHUDPuntaje>();
		ActualizarHUD();
	}

	public void SumarPuntaje(int puntos)
	{
		puntaje += puntos;
		ActualizarHUD();

		/*if (puntaje == 50)
		{
			controladorHUD.MostrarMensajeTemporal("¡¡NICE!!");
		}
		else if (puntaje == 100)
		{
			controladorHUD.MostrarMensajeTemporal("¡¡GREAT!!");
		}
		else if (puntaje == 150)
		{
			controladorHUD.MostrarMensajeTemporal("¡¡EXCELENT!!");
		}*/

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

	private void ActualizarHUD()
	{
		if (controladorHUDPuntaje != null)
		{
			controladorHUDPuntaje.ActualizarTextoPuntaje(ControladorPuntaje.Instancia.GetPuntaje().ToString());
			OnTextChanged.Invoke(ControladorPuntaje.Instancia.GetPuntaje().ToString());
		}
	}
}
