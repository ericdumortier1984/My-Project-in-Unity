using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoverEnemigo : MonoBehaviour
{
	[SerializeField]
	[Range(0, 5)] protected float velocidad;
	[SerializeField]
	[Range(0, 5)] protected float distancia;
	protected Vector2 posicionInicial;
	protected bool derecha = true;
	protected bool arriba = true;
	protected Rigidbody2D rb2D;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Mover();
	}
	protected abstract void Mover();
}
