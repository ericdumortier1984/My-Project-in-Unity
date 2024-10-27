using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoverBala : MonoBehaviour
{
    [SerializeField][Range(0, 50)] public float velocidad = 0f;
    private Rigidbody2D rb;

	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		Mover();
	}

	private void Mover()
	{
		Vector2 direccion = Vector2.right;
		rb.velocity = direccion * velocidad;
	}
}

