using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVerticalPlataforma : MonoBehaviour
{
	public float velocidad = 2f;
	public float distancia = 3f;
	private Vector2 posicionInicial;
	private bool arriba = true;

	void Start()
	{
		posicionInicial = transform.position;
	}

	void Update()
	{
		if (arriba)
		{
			transform.Translate(Vector2.up * velocidad * Time.deltaTime);

			if (transform.position.y >= posicionInicial.y + distancia)
			{
				arriba = false;

			}
		}
		else
		{
			transform.Translate(Vector2.down * velocidad * Time.deltaTime);

			if (transform.position.y <= posicionInicial.y - distancia)
			{
				arriba = true;
			}
		}
	}

	// Funciones para poder movernos junto con las plataformas
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (gameObject.activeInHierarchy) // verificar si el objeto esta activo
		{
			StartCoroutine(EsperarYAsignarPadre(collision.collider.transform, transform));
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (gameObject.activeInHierarchy) // verificar si el objeto esta activo
		{
			StartCoroutine(EsperarYDesasignarPadre(collision.collider.transform));
		}
	}

	private IEnumerator EsperarYAsignarPadre(Transform hijo, Transform padre)
	{
		yield return new WaitForEndOfFrame(); // Espera hasta el final del frame
		hijo.SetParent(padre);
	}

	private IEnumerator EsperarYDesasignarPadre(Transform hijo)
	{
		yield return new WaitForEndOfFrame(); // Espera hasta el final del frame
		hijo.SetParent(null);
	}
}

