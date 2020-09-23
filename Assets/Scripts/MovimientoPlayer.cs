using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float velocidad;

    private Rigidbody rb;
    private Transform camT;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camT = Camera.main.transform;
    }

    public int cantidadMonedas = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            ++cantidadMonedas;
            Debug.Log("[MovimientoPlayer] Junto moneda");
            GameObject.Destroy(other.gameObject);
        }
    }

    private float h;
    private float v;
    private float a;
    private Vector3 right;
    private Vector3 forward;
    public float velocidadRotacion = 1.0f;
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        a = Input.GetAxis("Aim");

        right = camT.right;
        right.y = 0.0f;
        right = right.normalized;

        forward = camT.forward;
        forward.y = 0.0f;
        forward = forward.normalized;
    }
    private Quaternion rot = Quaternion.identity;
    public float rotCoef = 1.0f;
    void FixedUpdate()
    {
        rb.velocity = (h * right + v * forward).normalized * velocidad;

        rot *= Quaternion.EulerRotation(a * Vector3.up * velocidadRotacion * Time.deltaTime);
        rb.rotation = Quaternion.Slerp(rb.rotation, rot, rotCoef);
        //Debug.Log($"[MovimientoPlayer] h={h} v={v} a={a} | right={right} forward={forward} | vel={rb.velocity} | rot={rb.rotation.eulerAngles}");
    }
}
