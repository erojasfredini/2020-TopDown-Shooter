using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 3.0f;
    public float radioExplosion = 3.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("[Bala] Bala colisiona");
        Collider[] enemigos = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach (var e in enemigos)
        {
            var eDummy = e.GetComponent<EnemigoDummy>();
            if (eDummy == null)
            {
                continue;
            }
            eDummy.RecibirDanio();
        }

        GameObject.Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = transform.up * velocidad;
        rb.position += transform.up * velocidad * Time.deltaTime;
        //Debug.Log($"[Bala] velocidad={rb.velocity}");
    }
}
