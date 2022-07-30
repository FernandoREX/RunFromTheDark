using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	//Variables para ayudar a generar monedas
	public GameObject obj;
	public float tiempoMin = 1f;
	public float tiempoMax = 2.9f;

	// Use this for initialization
	void Start () {
		Generar();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void Generar(){

		//Generacion de AlmaText
		Instantiate(obj, transform.position, Quaternion.identity);
		Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
	}
}
