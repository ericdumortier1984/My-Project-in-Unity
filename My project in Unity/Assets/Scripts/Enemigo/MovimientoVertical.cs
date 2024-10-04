using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVertical : MonoBehaviour
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
}
