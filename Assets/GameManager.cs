using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public Text Monedas;

    public int PuntosTotalesA { get { return puntosTotalesA; } }
    private int puntosTotalesA;
    public Text Almas;
    // Start is called before the first frame update
    public void SumarPuntos(int PuntosAsumar)
    {
        puntosTotales += PuntosAsumar;
        Monedas.text = "Monedas: " + puntosTotales;
        Debug.Log(puntosTotales);
    }

    public void SumarPuntosAlma(int PuntosAsumar)
    {
        puntosTotalesA += PuntosAsumar;
        Almas.text = "Trozos de Alma: " + puntosTotalesA;
        Debug.Log("Yoooo" + puntosTotalesA);
    }
}
