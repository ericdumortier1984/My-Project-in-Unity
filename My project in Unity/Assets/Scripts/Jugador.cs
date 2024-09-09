using System.Collections; // Importa el espacio de nombres para colecciones
using System.Collections.Generic; // Importa el espacio de nombres para colecciones gen�ricas
using UnityEngine; // Importa el espacio de nombres de Unity

public class Jugador : MonoBehaviour // Clase que representa al jugador
{
    [Header("Configuracion")] // Encabezado en el inspector para agrupar configuraciones
    [SerializeField] private float vida = 5f; // Vida actual del jugador, editable en el inspector
    private const float vidaMaxima = 5f; // Vida m�xima del jugador, constante
    public void ModificarVida(float puntos) // M�todo para modificar la vida del jugador
    {
        vida += puntos; // Modifica la vida actual sumando los puntos

        if (vida < 0) // Nos aseguramos que la vida no baje de cero
        {
            vida = 0; // Si la vida es menor que cero, se establece a cero
            Debug.Log("Perdiste"); // Mensaje de p�rdida
        }

        if (vida > vidaMaxima) // Aseguramos que la vida no exceda la m�xima
        {
            vida = vidaMaxima; // Si la vida es mayor que la m�xima, se establece a la m�xima
        }

        Debug.Log(EstasVivo()); // Imprime si el jugador est� vivo o no
    }
    private bool EstasVivo() // M�todo privado que verifica si el jugador est� vivo
    {
        return vida > 0; // Retorna verdadero si la vida es mayor que cero
    }
    private void OnTriggerEnter2D(Collider2D collision) // M�todo que se llama cuando el jugador colisiona con otro objeto
    {
        if (!collision.gameObject.CompareTag("Meta")) // Verifica si el objeto colisionado tiene la etiqueta "Meta"
        { 
           return; // Si no es la meta, sale del m�todo
        }  

        Destroy(collision.gameObject); // Destruye el objeto colisionado (la meta)
        Debug.Log("GANASTE"); // Mensaje de victoria
    }
}
