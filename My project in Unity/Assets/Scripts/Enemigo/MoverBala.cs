using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBala : MonoBehaviour
{
    public float velocidad = 0f;
    public float distancia = 0f;

    private Vector2 posicionInicial;
    private bool derecha = true;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (derecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
    }
}

