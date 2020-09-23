using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDummy : MonoBehaviour
{
    public GameObject prefabItem;
    private Transform player;
    public float velocidad = 3.0f;
    public float rotCoef = 0.1f;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            Debug.Log("[EnemigoDummy] Murio");
            GameObject.Instantiate(prefabItem, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }

    void Start()
    {
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var dir = (player.position - transform.position).normalized;

        rb.velocity = dir * velocidad;
        var objetivo = Quaternion.LookRotation(dir, Vector3.up);
        rb.rotation = Quaternion.Slerp(rb.rotation, objetivo, rotCoef);
    }
}
