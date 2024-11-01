using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;

public class Mover : MonoBehaviour 
{
    [SerializeField] private Vector2 velocidadRebotePorDaño; 

	private float moverHorizontal; 
    private Vector2 direccion; 
    private Rigidbody2D miRigidbody2D; 
    private Animator miAnimator; 
    private SpriteRenderer miSprite;
    private CircleCollider2D miCollider2D; 
    private Jugador jugador; 
	private int saltarMask; // Máscara de capas para detectar colisiones con plataformas.

    public bool sePuedemover = false;

    private void OnEnable() 
    {
		miRigidbody2D = GetComponent<Rigidbody2D>(); 
        miAnimator = GetComponent<Animator>(); 
        miSprite = GetComponent<SpriteRenderer>(); 
        miCollider2D = GetComponent<CircleCollider2D>(); 
        jugador = GetComponent<Jugador>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas"); // Crea una máscara de capas para detectar "Pisos" y "Plataformas".
    }

	private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal"); 
        direccion = new Vector2(moverHorizontal, 0f); 

        int velocidadX = (int)miRigidbody2D.velocity.x; 
        miSprite.flipX = velocidadX > 0; 
        miAnimator.SetInteger("Velocidad", velocidadX); 
        miAnimator.SetBool("EnAire", !EnContactoConPlataforma()); 
    }

    private void FixedUpdate() 
    {
        if (sePuedemover)
        {
            miRigidbody2D.AddForce(direccion * jugador.PerfilJugador.Velocidad); 
        }
    }
    private bool EnContactoConPlataforma() // Método que verifica si el objeto está en contacto con plataformas.
    {
        return miCollider2D.IsTouchingLayers(saltarMask); // Devuelve true si el Collider está tocando las capas definidas en saltarMask.
    }

    public void RebotePorDaño(Vector2 puntoDeContacto) // Método para manejar el rebote al recibir daño.
    {
        // Establece la velocidad del Rigidbody2D para que rebote en la dirección opuesta al punto de contacto.
        miRigidbody2D.velocity = new Vector2(-velocidadRebotePorDaño.x * puntoDeContacto.x, 
            velocidadRebotePorDaño.y * puntoDeContacto.y);
    }
}