using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CamaraJugador : MonoBehaviour
{
    public GameObject Jugado; //Objeto jugador principal
    public Camera CamaraP;    //Camara del juego

    public GameObject[] BloquesPreFabricadosInicio; //Arreglo donde se guardaran los distintos escenarios del inicio
    public GameObject[] BloquesPreFabricadosMedio; //Arreglo donde se guardaran los distintos escenarios del intermedio
    public GameObject[] BloquesPreFabricadosAvanzado; //Arreglo donde se guardaran los distintos escenarios del Avanzado

    public float PunteroDelJuego;
    public float LugarGeneracion = 12; //Lugar donde se generara por primera vez el personaje

    public Text TextoDelJuego; //Puntos del juego
    public Text Monedas; //AlmaText del juego
    public Text TrozosAlma; //Alma texto del juego
    public bool Muerto; //Variable si el jugador esta vivo o muerto

    public GameObject Generador; //Generdor de Monedas
    public GameObject GeneradorAlmas; //Generador de trozos de alma

    public GameObject Musica; //Musica del juego
    public GameObject MusicaMuerte; //Musica de la muerte del juego

    // Start is called before the first frame update
    void Start()
    {
        PunteroDelJuego = -7;
        Muerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Sigue al jugador siempre que el jugador sea diferente de null
        //(NO este destruido)
        if (Jugado != null)  
        {
            //Codigo para que la camara siga al jugador
            CamaraP.transform.position = new Vector3(
                Jugado.transform.position.x,
                CamaraP.transform.position.y,
                CamaraP.transform.position.z);

            Generador.transform.position = new Vector3(
                Jugado.transform.position.x + 20,
                CamaraP.transform.position.y - 1,
                CamaraP.transform.position.z + 1);

            GeneradorAlmas.transform.position = new Vector3(
                Jugado.transform.position.x + 20,
                CamaraP.transform.position.y - 1,
                CamaraP.transform.position.z + 1);

            //Puntaje del jugador
            TextoDelJuego.text = "Puntaje: " + Mathf.Floor(Jugado.transform.position.x);
        }
        else
        {
            if (!Muerto)
            {
                Muerto = true;
                TextoDelJuego.text += "\nNo intentes escapar! ";
                TextoDelJuego.text += "\nPresiona R para volver a empezar";
                TextoDelJuego.color = Color.red;
                Monedas.color = Color.red;
                TrozosAlma.color = Color.red;
                Destroy(Musica);
                Instantiate(MusicaMuerte);
            }
            if (Muerto) //Estamos muertos
            {
                if (Input.GetKeyDown("r")) //Presionamos "R"
                {
                    //Se vuelve a acargar el juego
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        if(Jugado.transform.position.y < -15)
        {
            GameObject.Destroy(Jugado);
        }

        //Generador de nivel facil
        if (Mathf.Floor(Jugado.transform.position.x) < 100)
        {
            

            //Codigo de generacion automatico de los niveles ya existentes
            while (Jugado != null && PunteroDelJuego < Jugado.transform.position.x + LugarGeneracion)
            {
                int indiceDelBloque = Random.Range(0, BloquesPreFabricadosInicio.Length - 1);
                if (PunteroDelJuego < 0) //Nos ayuda a que el primer bloque sea el mas seguro
                {
                    indiceDelBloque = 6;
                }
                //Creamos el bloque 
                GameObject ObjetoBloque = Instantiate(BloquesPreFabricadosInicio[indiceDelBloque]);
                ObjetoBloque.transform.SetParent(this.transform); //Lo creamos dentro de "ControladorEscena"
                                                                  //Nos permite sacar componentes del bloque
                Bloque bloque = ObjetoBloque.GetComponent<Bloque>();
                //Creamos los bloques del juego
                ObjetoBloque.transform.position = new Vector2(
                    PunteroDelJuego + bloque.Tamaño / 2,
                    0);
                PunteroDelJuego += bloque.Tamaño;
                
            }
        }

        

        //Generador de nivel intermedio
        if (Mathf.Floor(Jugado.transform.position.x) > 100 && Mathf.Floor(Jugado.transform.position.x) < 250)
        {
            //Codigo de generacion automatico de los niveles ya existentes
            while (Jugado != null && PunteroDelJuego < Jugado.transform.position.x + LugarGeneracion)
            {
                int indiceDelBloque = Random.Range(0, BloquesPreFabricadosMedio.Length - 1);
                if (PunteroDelJuego < 0) //Nos ayuda a que el primer bloque sea el mas seguro
                {
                    indiceDelBloque = 6;
                }
                //Creamos el bloque 
                GameObject ObjetoBloque = Instantiate(BloquesPreFabricadosMedio[indiceDelBloque]);
                ObjetoBloque.transform.SetParent(this.transform); //Lo creamos dentro de "ControladorEscena"
                                                                  //Nos permite sacar componentes del bloque
                Bloque bloque = ObjetoBloque.GetComponent<Bloque>();
                //Creamos los bloques del juego
                ObjetoBloque.transform.position = new Vector2(
                    PunteroDelJuego + bloque.Tamaño / 2,
                    0);
                PunteroDelJuego += bloque.Tamaño;
            }
            
        }

        //Generador de nivel Avanzado
        if (Mathf.Floor(Jugado.transform.position.x) > 250)
        {
            //Codigo de generacion automatico de los niveles ya existentes
            while (Jugado != null && PunteroDelJuego < Jugado.transform.position.x + LugarGeneracion)
            {
                int indiceDelBloque = Random.Range(0, BloquesPreFabricadosAvanzado.Length - 1);
                if (PunteroDelJuego < 0) //Nos ayuda a que el primer bloque sea el mas seguro
                {
                    indiceDelBloque = 6;
                }
                //Creamos el bloque 
                GameObject ObjetoBloque = Instantiate(BloquesPreFabricadosAvanzado[indiceDelBloque]);
                ObjetoBloque.transform.SetParent(this.transform); //Lo creamos dentro de "ControladorEscena"
                                                                  //Nos permite sacar componentes del bloque
                Bloque bloque = ObjetoBloque.GetComponent<Bloque>();
                //Creamos los bloques del juego
                ObjetoBloque.transform.position = new Vector2(
                    PunteroDelJuego + bloque.Tamaño / 2,
                    0);
                PunteroDelJuego += bloque.Tamaño;
            }
        }

    }


}
