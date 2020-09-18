using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPlayer : MonoBehaviour
{
    public Transform objetivo;
    private Vector3 desplazamiento;
    void Start()
    {
        desplazamiento = transform.position - objetivo.position;
    }

    public float velocidad = 1.0f;

    void Update()
    {
        Vector3 target = objetivo.position + desplazamiento;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * velocidad);
    }
}
