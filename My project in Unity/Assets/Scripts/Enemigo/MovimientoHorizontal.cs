using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MoverEnemigo
{
	void Start()
	{
		posicionInicial = transform.position;
	}

	protected override void Mover()
	{

		if (derecha)
		{
			transform.Translate(Vector2.right * velocidad * Time.deltaTime);

			if (transform.position.x >= posicionInicial.x + distancia)
			{
				derecha = false;

			}
		}
		else
		{
			transform.Translate(Vector2.left * velocidad * Time.deltaTime);

			if (transform.position.x <= posicionInicial.x - distancia)
			{
				derecha = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Trampolin"))
		{
			Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
		}
	}

}
