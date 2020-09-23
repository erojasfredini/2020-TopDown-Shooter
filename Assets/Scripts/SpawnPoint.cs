using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public float timepoSpawn = 1.0f;
    public int cantidadMaxEnemigos = 6;

    void Start()
    {
        InvokeRepeating("SpawnNuevo", timepoSpawn, timepoSpawn);
    }

    void SpawnNuevo()
    {
        var enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        if (enemigos.Length < cantidadMaxEnemigos)
        {
            GameObject.Instantiate(prefabEnemigo, transform.position, Quaternion.identity);
        }
    }
}
