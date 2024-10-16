using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorUI : MonoBehaviour
{
	public void CargarSiguienteEscena()
	{
		int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(indiceEscenaActual + 1);
	}
}
