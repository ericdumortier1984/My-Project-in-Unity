using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Palanca : MonoBehaviour
{
	[SerializeField] private UnityEvent OnPalancaTriggered;

	public Coleccionables coleccionables;

	private void Start()
	{
		if (coleccionables == null)
		{
			coleccionables = FindObjectOfType<Coleccionables>();
		}
	}

		private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			OnPalancaTriggered.Invoke();
			coleccionables.ActivarMetas();
		}
	}
}
