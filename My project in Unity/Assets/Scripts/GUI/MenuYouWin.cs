using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuYouWin : MonoBehaviour
{
    public GameObject menuYouWin; // Referencia al men� de Game Over
    public void MostrarMenuYouWin() // M�todo para mostrar el men� Game Over
    {
        menuYouWin.SetActive(true); // Activa el men�
    }
}
