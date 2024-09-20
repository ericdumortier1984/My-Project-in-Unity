using System.Collections; // Importa el espacio de nombres para colecciones (no utilizado en este script).
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genéricas (no utilizado en este script).
using UnityEngine; // Importa el espacio de nombres de Unity para acceder a sus funciones y clases.

public class Mover : MonoBehaviour // Define una clase llamada Mover que hereda de MonoBehaviour.
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]  // Añade un encabezado en el editor para agrupar configuraciones.
    [SerializeField] float velocidad = 5f; // Velocidad de movimiento del objeto, editable desde el inspector.
    [SerializeField] private Vector2 velocidadRebotePorDaño; // Velocidad de rebote al recibir daño, editable desde el inspector.

    // Variables de uso interno en el script
    private float moverHorizontal; // Almacena la entrada horizontal del jugador.
    private Vector2 direccion; // Almacena la dirección de movimiento.

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D; // Referencia al componente Rigidbody2D del objeto.
    private Animator miAnimator; // Referencia al componente Animator del objeto.
    private SpriteRenderer miSprite; // Referencia al componente SpriteRenderer del objeto.
    private CircleCollider2D miCollider2D; // Referencia al componente CircleCollider2D del objeto.

    private int saltarMask; // Máscara de capas para detectar colisiones con plataformas.

    public bool sePuedemover; // Bandera que indica si el objeto puede moverse.

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable() // Método que se llama cuando el objeto se activa.
    {
        // Inicializa las referencias a los componentes.
        miRigidbody2D = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D.
        miAnimator = GetComponent<Animator>(); // Obtiene el componente Animator.
        miSprite = GetComponent<SpriteRenderer>(); // Obtiene el componente SpriteRenderer.
        miCollider2D = GetComponent<CircleCollider2D>(); // Obtiene el componente CircleCollider2D.
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas"); // Crea una máscara de capas para detectar "Pisos" y "Plataformas".
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update() // Método que se llama una vez por frame.
    {
        moverHorizontal = Input.GetAxis("Horizontal"); // Obtiene la entrada horizontal del jugador (-1 a 1).
        direccion = new Vector2(moverHorizontal, 0f); // Crea un vector de dirección basado en la entrada horizontal.

        int velocidadX = (int)miRigidbody2D.velocity.x; // Obtiene la velocidad horizontal actual del Rigidbody2D.
        miSprite.flipX = velocidadX > 0; // Voltea el sprite si se mueve a la derecha.
        miAnimator.SetInteger("Velocidad", velocidadX); // Establece el parámetro "Velocidad" del Animator.
        miAnimator.SetBool("EnAire", !EnContactoConPlataforma()); // Cambia el estado "EnAire" dependiendo de si está en contacto con una plataforma.
    }

    private void FixedUpdate() // Método que se llama en intervalos fijos, adecuado para físicas.
    {
        if (sePuedemover) // Verifica si el objeto puede moverse.
        {
            miRigidbody2D.AddForce(direccion * velocidad); // Aplica una fuerza al Rigidbody2D en la dirección deseada.
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