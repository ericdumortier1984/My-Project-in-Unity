using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public GameObject menuGameOver; // Referencia al menú de Game Over
   

    public void MostrarMenuGameOver() // Método para mostrar el menú Game Over
    {
        menuGameOver.SetActive(true); // Activa el menú
    }
}
