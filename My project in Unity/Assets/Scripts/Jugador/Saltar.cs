using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private ParticleSystem polvo;
    [SerializeField] float rayDistancia;
    [SerializeField] LayerMask capaPiso;

    // Variables privadas
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variables publicas
    public bool mejorarSalto = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;
    private Jugador jugador;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
        jugador = GetComponent<Jugador>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        puedoSaltar = EsPiso();

        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            saltando = true;
            polvo.Play();
           
			if (miAudioSource.isPlaying) { return; }
			miAudioSource.PlayOneShot(jugador.PerfilJugador.JumpSFX, jugador.PerfilJugador.VolumenSaltoSFX);
		}
    }

    private void FixedUpdate()
    {
        if (saltando)
        {
			miRigidbody2D.AddForce(Vector2.up * jugador.PerfilJugador.FuerzaSalto, ForceMode2D.Impulse);
            saltando = false;
        }

        if (mejorarSalto) // Opcionalmente desde el editor podemos elejir entre salto normal o mejorado
        {
            if (miRigidbody2D.velocity.y < 0)
            {
                miRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (jugador.PerfilJugador.MultiplicadorCaida) * Time.deltaTime;
            }

			if (miRigidbody2D.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
			{
				miRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (jugador.PerfilJugador.MultiplicadorSaltoBajo) * Time.deltaTime;
			}
		}
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        saltando = false;
    }

    private bool EsPiso()
    {
        RaycastHit2D raycasthit2D = Physics2D.Raycast(transform.position, Vector2.down, rayDistancia, capaPiso);
        return raycasthit2D.collider != null;
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistancia);
	}
}
