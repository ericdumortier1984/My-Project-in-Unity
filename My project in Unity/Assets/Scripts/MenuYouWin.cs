using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuYouWin : MonoBehaviour
{
    public GameObject menuYouWin; // Referencia al menú de Game Over
    public void MostrarMenuYouWin() // Método para mostrar el menú Game Over
    {
        menuYouWin.SetActive(true); // Activa el menú
    }
}
