using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPlayer : MonoBehaviour
{
    public GameObject prefabBala;
    public Transform origenArma;

    void Start()
    {
    }

    private float tiempoUltimoDisparo = 0.0f;
    public float tiempoCoolDown = 0.1f;

    void Update()
    {
        bool dispara = Input.GetButton("Fire1");

        bool puedeDisparar = (Time.time - tiempoUltimoDisparo) > tiempoCoolDown;
        if (dispara && puedeDisparar)
        {
            GameObject.Instantiate(prefabBala, origenArma.position, origenArma.rotation);
            tiempoUltimoDisparo = Time.time;
            Debug.Log("[ArmaPlayer] Disparando!");
        }
    }
}
