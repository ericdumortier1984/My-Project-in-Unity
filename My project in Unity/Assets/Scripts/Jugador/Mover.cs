using System.Collections; // Importa el espacio de nombres para colecciones (no utilizado en este script).
using System.Collections.Generic; // Importa el espacio de nombres para colecciones gen�ricas (no utilizado en este script).
using UnityEngine; // Importa el espacio de nombres de Unity para acceder a sus funciones y clases.

public class Mover : MonoBehaviour // Define una clase llamada Mover que hereda de MonoBehaviour.
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]  // A�ade un encabezado en el editor para agrupar configuraciones.
    [SerializeField] float velocidad = 5f; // Velocidad de movimiento del objeto, editable desde el inspector.
    [SerializeField] private Vector2 velocidadRebotePorDa�o; // Velocidad de rebote al recibir da�o, editable desde el inspector.

    // Variables de uso interno en el script
    private float moverHorizontal; // Almacena la entrada horizontal del jugador.
    private Vector2 direccion; // Almacena la direcci�n de movimiento.

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D; // Referencia al componente Rigidbody2D del objeto.
    private Animator miAnimator; // Referencia al componente Animator del objeto.
    private SpriteRenderer miSprite; // Referencia al componente SpriteRenderer del objeto.
    private CircleCollider2D miCollider2D; // Referencia al componente CircleCollider2D del objeto.

    private int saltarMask; // M�scara de capas para detectar colisiones con plataformas.

    public bool sePuedemover; // Bandera que indica si el objeto puede moverse.

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable() // M�todo que se llama cuando el objeto se activa.
    {
        // Inicializa las referencias a los componentes.
        miRigidbody2D = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D.
        miAnimator = GetComponent<Animator>(); // Obtiene el componente Animator.
        miSprite = GetComponent<SpriteRenderer>(); // Obtiene el componente SpriteRenderer.
        miCollider2D = GetComponent<CircleCollider2D>(); // Obtiene el componente CircleCollider2D.
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas"); // Crea una m�scara de capas para detectar "Pisos" y "Plataformas".
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update() // M�todo que se llama una vez por frame.
    {
        moverHorizontal = Input.GetAxis("Horizontal"); // Obtiene la entrada horizontal del jugador (-1 a 1).
        direccion = new Vector2(moverHorizontal, 0f); // Crea un vector de direcci�n basado en la entrada horizontal.

        int velocidadX = (int)miRigidbody2D.velocity.x; // Obtiene la velocidad horizontal actual del Rigidbody2D.
        miSprite.flipX = velocidadX > 0; // Voltea el sprite si se mueve a la derecha.
        miAnimator.SetInteger("Velocidad", velocidadX); // Establece el par�metro "Velocidad" del Animator.
        miAnimator.SetBool("EnAire", !EnContactoConPlataforma()); // Cambia el estado "EnAire" dependiendo de si est� en contacto con una plataforma.
    }

    private void FixedUpdate() // M�todo que se llama en intervalos fijos, adecuado para f�sicas.
    {
        if (sePuedemover) // Verifica si el objeto puede moverse.
        {
            miRigidbody2D.AddForce(direccion * velocidad); // Aplica una fuerza al Rigidbody2D en la direcci�n deseada.
        }
    }
    private bool EnContactoConPlataforma() // M�todo que verifica si el objeto est� en contacto con plataformas.
    {
        return miCollider2D.IsTouchingLayers(saltarMask); // Devuelve true si el Collider est� tocando las capas definidas en saltarMask.
    }

    public void RebotePorDa�o(Vector2 puntoDeContacto) // M�todo para manejar el rebote al recibir da�o.
    {
        // Establece la velocidad del Rigidbody2D para que rebote en la direcci�n opuesta al punto de contacto.
        miRigidbody2D.velocity = new Vector2(-velocidadRebotePorDa�o.x * puntoDeContacto.x, 
            velocidadRebotePorDa�o.y * puntoDeContacto.y);
    }
}