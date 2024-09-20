using System.Collections; // Importa el espacio de nombres para usar colecciones genéricas.
using System.Collections.Generic; // Importa el espacio de nombres para usar colecciones genéricas.
using UnityEngine; // Importa el espacio de nombres de Unity.
using UnityEngine.Rendering.Universal; // Importa el espacio de nombres para el sistema de renderizado universal.

public class GeneradorDiaNoche : MonoBehaviour // Define la clase "GeneradorDiaNoche" que hereda de MonoBehaviour.
{
    [SerializeField] private Camera camara; // Referencia a la cámara que se usará para cambiar el color de fondo.
    [SerializeField] private Color nocheColor; // Color que se usará durante la noche.
    [SerializeField] private Light2D luz2D; // Referencia a la luz 2D que se ajustará entre día y noche.

    [SerializeField][Range(1, 128)] private int duracionDia; // Duración del ciclo de día en segundos, con un rango de 1 a 128.
    [SerializeField][Range(1, 24)] private int dias; // Número de ciclos de día/noche que se repetirán, con un rango de 1 a 24.

    private Color diaColor; // Variable para almacenar el color de fondo del día.

    void Start() // Método que se llama al iniciar el script.
    {
        diaColor = camara.backgroundColor; // Almacena el color actual de fondo de la cámara como el color de día.
        StartCoroutine(CambiarColor(duracionDia)); // Inicia la coroutine para cambiar el color.
    }

    IEnumerator CambiarColor(float tiempo) // Coroutine que cambia el color de fondo y la luz.
    {
        Color colorDestinoFondo = camara.backgroundColor == diaColor ? nocheColor : diaColor; // Define el color de fondo de destino según el estado actual (día o noche).
        Color colorDestinoLuz = luz2D.color != Color.white ? Color.white : nocheColor; // Define el color de destino de la luz según su estado actual.
        float duracionCiclo = tiempo * 0.6f; // Duración del ciclo (día/noche) dividido en dos partes.
        float duracionCambio = tiempo * 0.4f; // Duración del cambio de color.

        for (int i = 0; i < dias; i++) // Bucle para repetir el ciclo de día/noche por el número de días especificado.
        {
            yield return new WaitForSeconds(duracionCiclo); // Espera la duración del ciclo antes de comenzar a cambiar colores.

            float tiempoTranscurrido = 0; // Inicializa el tiempo transcurrido en 0.

            while (tiempoTranscurrido < duracionCambio) // Bucle que cambia el color gradualmente.
            {
                tiempoTranscurrido += Time.deltaTime; // Incrementa el tiempo transcurrido según el tiempo real.
                float t = tiempoTranscurrido / duracionCambio; // Calcula la proporción del tiempo transcurrido.

                float smoothT = Mathf.SmoothStep(0f, 1f, t); // Suaviza el valor de t para una transición más fluida.

                // Cambia el color de fondo de la cámara y la luz 2D de manera interpolada.
                camara.backgroundColor = Color.Lerp(camara.backgroundColor, colorDestinoFondo, smoothT); 
                luz2D.color = Color.Lerp(luz2D.color, colorDestinoLuz, smoothT);

                yield return null; // Espera el siguiente frame antes de continuar.
            }

            // Cambia los colores de destino para el siguiente ciclo.
            colorDestinoLuz = luz2D.color != Color.white ? Color.white : nocheColor;
            colorDestinoFondo = camara.backgroundColor == diaColor ? nocheColor : diaColor;

        }
    }
}

