using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public GameObject menuGameOver; // Referencia al men� de Game Over
   

    public void MostrarMenuGameOver() // M�todo para mostrar el men� Game Over
    {
        menuGameOver.SetActive(true); // Activa el men�
    }
}
