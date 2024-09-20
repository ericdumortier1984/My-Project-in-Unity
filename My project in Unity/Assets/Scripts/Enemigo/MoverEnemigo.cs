using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 3f;

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
}
