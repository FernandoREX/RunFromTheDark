using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrinciapl : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Animations111");
    } 

    public void Salir()
    {
        Application.Quit();
    }
}
