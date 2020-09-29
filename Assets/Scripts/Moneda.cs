using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float velocidadRotacion = 10.0f;

    void FixedUpdate()
    {
        var rot = Vector3.up * velocidadRotacion * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(rot);
        //Debug.Log($"[Moneda] rotEje={rot}");
    }
}
