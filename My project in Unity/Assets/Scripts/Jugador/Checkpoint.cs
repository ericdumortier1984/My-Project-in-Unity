using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Momentaneamente el chechpoint solo guarda la posicion del jugador
 * Para reestablecer la posicion original: Edit/Clear All PlayerPrefs 
 */

public class Checkpoint : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<JugadorRespawn>().CheckpointEncontardo(transform.position.x, transform.position.y);
			GetComponent<Animator>().enabled = true;
		}
	}
}
