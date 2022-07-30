using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Timers;

public class jugador : MonoBehaviour
{
    public int FuerzaSalto;
    public int VelocidadMovimiento;
    bool EnElPiso = false;

    public BoxCollider2D MiBoxCollider;

    //Variables para que aumente la velocidad del jugador
    public float Incremento;
    float TiempoActual;

    //Variables para cambiar color
    [SerializeField] private AnimatorOverrideController LeoFantasma;
    private RuntimeAnimatorController LeoNormal;
    private Animator AJugador;

    //Varias para la musica
    public GameObject SonidoSalto;
    public GameObject SonidoTransformacion;

    // Start is called before the first frame update
    void Start()
    {
        TiempoActual = Incremento * 60; //Aumento de velocidad cada 60 cuadros
        AJugador = GetComponent<Animator>();
        LeoNormal = AJugador.runtimeAnimatorController; //Guardamos animacion Actual
    }

    // Update is called once per frame
    void Update()
    {
        TiempoActual -= 1f; //Aumento de Velocidad

        //Codigo para saltar
        if (Input.GetKeyDown("space") && EnElPiso)
        {
            //---------Codigo para sonido de saltar---------
            Instantiate(SonidoSalto);

            //---------Codigo para saltar---------
            EnElPiso = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaSalto));
        }

        //Codigo para avanzar en el Endless Runer
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadMovimiento,
            this.GetComponent<Rigidbody2D>().velocity.y);

        if(Input.GetKeyDown(KeyCode.W))
        {
            //---------Codigo para sonido de Trasformacion---------
            Instantiate(SonidoTransformacion);

            MiBoxCollider.enabled = false;
            AJugador.runtimeAnimatorController = LeoFantasma as RuntimeAnimatorController;
            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            //---------Codigo para sonido de Trasformacion---------
            Instantiate(SonidoTransformacion);

            MiBoxCollider.enabled = true;
            AJugador.runtimeAnimatorController = LeoNormal as RuntimeAnimatorController;
        }

        //Aumento de Velocidad segun el tiempo
        if(TiempoActual < 0)
        {
            VelocidadMovimiento += 1;
            TiempoActual = Incremento * 60;
        }

        //Codigo para morir al atravesar la parte inferior
        Transform posicion; //Variable para saber la posicion
        posicion = gameObject.transform;

        if(posicion.position.y < -5.8) //Codigo para morir
        {
            GameObject.Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnElPiso = true;
        if(collision.collider.gameObject.tag == "Obstaculo")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    /**
     *La dos funciones nos dice si "El jugador" esta en el piso y cambia la 
     *variable "EnElPiso" de "false" a "true" o la deja igual segun sea
     *el caso
     */
    

    //-------------------------------------------------------------------------


}
