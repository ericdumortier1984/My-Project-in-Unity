using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVertical : MoverEnemigo
{
	void Start()
	{
		posicionInicial = transform.position;
	}
	protected override void Mover()
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
