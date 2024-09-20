using System.Collections; // Importa el espacio de nombres para colecciones
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genéricas
using UnityEngine; // Importa el espacio de nombres de Unity
using UnityEngine.SceneManagement; // Importa el manejo de escenas

public class Jugador : MonoBehaviour // Clase que representa al jugador
{
    // -------- Headers ---------------- //
    [Header("Configuracion")] // Encabezado en el inspector para agrupar configuraciones

    // -------- SerializeFields -------- //
    [SerializeField] private float vida = 5f; // Vida actual del jugador, editable en el inspector
    [SerializeField] private float TiempoNoControlJugador;

    // -------- Variables privadas ----- //
    private const float vidaMaxima = 5f; // Vida máxima del jugador, constante
    private MenuGameOver menuGameOver; // Referencia al script MenuGameOver
    private MenuYouWin menuYouWin; // Referencia al script MenuYouWin

    private Mover movimientoJugador;
    private Animator animatorJugador;

    private int metasRecogidas = 0; // Contador de metas recogidas
    private int totalMetas; // Total de metas en la escena

    private void Start()
    {
        menuGameOver = FindObjectOfType<MenuGameOver>(); // Busca el componente MenuGameOver en la escena
        menuYouWin = FindObjectOfType<MenuYouWin>(); // Busca el componenete MenuYouWin en la escena
        totalMetas = GameObject.FindGameObjectsWithTag("Meta").Length; // Cuenta el total de metas en la escena
        movimientoJugador = GetComponent<Mover>();
        animatorJugador = GetComponent<Animator>();
    }


    public void ModificarVida(float puntos) // Método para modificar la vida del jugador
    {
        vida += puntos; // Modifica la vida actual sumando los puntos

        if (vida <= 0) // Nos aseguramos que la vida no baje de cero
        {
            SceneManager.LoadScene("EscenaGameOver"); // Carga escena de Game Over
        }

        if (vida > vidaMaxima) // Aseguramos que la vida no exceda la máxima
        {
            vida = vidaMaxima; // Si la vida es mayor que la máxima, se establece a la máxima
        }

        Debug.Log(EstasVivo()); // Imprime si el jugador está vivo o no
    }
    private bool EstasVivo() // Método privado que verifica si el jugador está vivo
    {
        return vida > 0; // Retorna verdadero si la vida es mayor que cero
    }
    private void OnTriggerEnter2D(Collider2D collision) // Método que se llama cuando el jugador colisiona con otro objeto
    {
        if (!collision.gameObject.CompareTag("Meta")) // Verifica si el objeto colisionado tiene la etiqueta "Meta"
        {
            return; // Si no es la meta, sale del método
        }  

        Destroy(collision.gameObject); // Destruye el objeto colisionado (la meta)
        metasRecogidas++; // Incrementa el contador de metas recogidas

        if (metasRecogidas >= totalMetas) // Verifica si se han recogido todas las metas
        {
            SceneManager.LoadScene("EscenaYouWin"); // Carga escena de victoria
        }
    }

    public void HerirJugador(float puntos, Vector2 posicion)
    {
        vida -= puntos;
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
        yield return new WaitForSeconds(TiempoNoControlJugador);
        Physics2D.IgnoreLayerCollision(7, 9, false);
    }

    private IEnumerator PerderControlJugador()
    {
        movimientoJugador.sePuedemover = false;
        yield return new WaitForSeconds(TiempoNoControlJugador);
        movimientoJugador.sePuedemover = true;
    }
}
