using System.Collections; // Importa el espacio de nombres para usar colecciones gen�ricas.
using System.Collections.Generic; // Importa el espacio de nombres para usar colecciones gen�ricas.
using UnityEngine; // Importa el espacio de nombres de Unity.
using UnityEngine.Rendering.Universal; // Importa el espacio de nombres para el sistema de renderizado universal.

public class GeneradorDiaNoche : MonoBehaviour // Define la clase "GeneradorDiaNoche" que hereda de MonoBehaviour.
{
    [SerializeField] private Camera camara; // Referencia a la c�mara que se usar� para cambiar el color de fondo.
    [SerializeField] private Color nocheColor; // Color que se usar� durante la noche.
    [SerializeField] private Light2D luz2D; // Referencia a la luz 2D que se ajustar� entre d�a y noche.

    [SerializeField][Range(1, 128)] private int duracionDia; // Duraci�n del ciclo de d�a en segundos, con un rango de 1 a 128.
    [SerializeField][Range(1, 24)] private int dias; // N�mero de ciclos de d�a/noche que se repetir�n, con un rango de 1 a 24.

    private Color diaColor; // Variable para almacenar el color de fondo del d�a.

    void Start() // M�todo que se llama al iniciar el script.
    {
        diaColor = camara.backgroundColor; // Almacena el color actual de fondo de la c�mara como el color de d�a.
        StartCoroutine(CambiarColor(duracionDia)); // Inicia la coroutine para cambiar el color.
    }

    IEnumerator CambiarColor(float tiempo) // Coroutine que cambia el color de fondo y la luz.
    {
        Color colorDestinoFondo = camara.backgroundColor == diaColor ? nocheColor : diaColor; // Define el color de fondo de destino seg�n el estado actual (d�a o noche).
        Color colorDestinoLuz = luz2D.color != Color.white ? Color.white : nocheColor; // Define el color de destino de la luz seg�n su estado actual.
        float duracionCiclo = tiempo * 0.6f; // Duraci�n del ciclo (d�a/noche) dividido en dos partes.
        float duracionCambio = tiempo * 0.4f; // Duraci�n del cambio de color.

        for (int i = 0; i < dias; i++) // Bucle para repetir el ciclo de d�a/noche por el n�mero de d�as especificado.
        {
            yield return new WaitForSeconds(duracionCiclo); // Espera la duraci�n del ciclo antes de comenzar a cambiar colores.

            float tiempoTranscurrido = 0; // Inicializa el tiempo transcurrido en 0.

            while (tiempoTranscurrido < duracionCambio) // Bucle que cambia el color gradualmente.
            {
                tiempoTranscurrido += Time.deltaTime; // Incrementa el tiempo transcurrido seg�n el tiempo real.
                float t = tiempoTranscurrido / duracionCambio; // Calcula la proporci�n del tiempo transcurrido.

                float smoothT = Mathf.SmoothStep(0f, 1f, t); // Suaviza el valor de t para una transici�n m�s fluida.

                // Cambia el color de fondo de la c�mara y la luz 2D de manera interpolada.
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

