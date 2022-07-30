using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaNiveles : MonoBehaviour
{
    public AudioSource AuidiosI;
    public AudioSource AuidiosII;

    public void SeleccionAudios()
    {
        AuidiosI.Play();
        AuidiosI.volume = 0.3f;
    }

    public void MusicaNivel2()
    {
        AuidiosII.Play();
        AuidiosI.volume = 0.4f;
    }
}
