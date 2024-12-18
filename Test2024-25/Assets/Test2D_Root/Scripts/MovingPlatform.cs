using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 5; // velocidad de la plataforma
    [SerializeField] int startingPoint; // determinador del punto de inicio de la plataforma
    [SerializeField] Transform[] points; //array que almacena la posición de los diferentes puntos
    int i; //indice del array = punto al que va a perseguir la plataforma

    // Start is called before the first frame update
    void Start()
    {
        // al inicio del juego la plataforma se teleporta a la posición de igual valor que startinPoint
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {

        MovePlatform();
    }

    void MovePlatform()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f) 
        { 
            i++; //suma 1 al valor del indice, persigue el siguiente punto 
            if (i == points.Length) i = 0; //resetea el circuito de puntos
        }
        //mueve la plataforma a la posición del punto en el array que coincide con el valor de indice
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
