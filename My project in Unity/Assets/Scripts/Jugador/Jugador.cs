using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Jugador : MonoBehaviour 
{
	[SerializeField] 
	private PerfilJugador perfilJugador;
	public PerfilJugador PerfilJugador { get => perfilJugador; }

	// -------- Referencias a scripts ----- //
    private MenuGameOver menuGameOver; 
    private MenuYouWin menuYouWin;
    private Mover movimientoJugador;
    private Animator animatorJugador;
	private AudioSource miAudioSource;
    private Progresion progresionJugador;
    private Coleccionables coleccionables;

	private void Start()
    {
        menuGameOver = FindObjectOfType<MenuGameOver>(); 
        menuYouWin = FindObjectOfType<MenuYouWin>();
        coleccionables = FindObjectOfType<Coleccionables>();
		movimientoJugador = GetComponent<Mover>();
        animatorJugador = GetComponent<Animator>();
		miAudioSource = GetComponent<AudioSource>();
        progresionJugador = GetComponent<Progresion>();
	}

	private void Update()
	{
		Debug.Log(PerfilJugador.Nivel);
	}

	public void ModificarVida(int puntos) 
    {
        PerfilJugador.Vida += puntos; 

        if (PerfilJugador.Vida <= 0) 
        {
            SceneManager.LoadScene("EscenaGameOver"); 
        }

        if (PerfilJugador.Vida > PerfilJugador.VidaMaxima) 
        {
            PerfilJugador.Vida = PerfilJugador.VidaMaxima; 
        }
    }
    private bool EstasVivo() 
    {
        return PerfilJugador.Vida > 0; 
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (!collision.gameObject.CompareTag("Meta")) 
        {
            return; 
        }

        coleccionables.RecogerMeta(collision.gameObject);
        PerfilJugador.Nivel++;
        
		if (miAudioSource.isPlaying) { return; }
		miAudioSource.PlayOneShot(PerfilJugador.DiamanteSFX, PerfilJugador.VolumenDiamanteSFX);
		
        if(coleccionables.TodasLasMetasRecogidas())
        {
            SceneManager.LoadScene("EscenaYouWin"); 
        }
    }

    public void HerirJugador(int puntos, Vector2 posicion)
    {
        PerfilJugador.Vida -= puntos;
        animatorJugador.SetTrigger("Golpe");
        // Perder control del Jugador
        StartCoroutine(PerderControlJugador());
        // Desactivar colision
        StartCoroutine(DesactivarColisionConEnemigos());
        movimientoJugador.RebotePorDaño(posicion);
    }

    private IEnumerator DesactivarColisionConEnemigos()
    {
        Physics2D.IgnoreLayerCollision(7, 9, true);
        yield return new WaitForSeconds(PerfilJugador.InactividadPorColision);
        Physics2D.IgnoreLayerCollision(7, 9, false);
    }

    private IEnumerator PerderControlJugador()
    {
        movimientoJugador.sePuedemover = false;
        yield return new WaitForSeconds(PerfilJugador.InactividadPorColision);
        movimientoJugador.sePuedemover = true;
    }
}
