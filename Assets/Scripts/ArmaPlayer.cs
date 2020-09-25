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

    private float tiempoUltimoDisparoMisil = 0.0f;
    public float tiempoCoolDownMisil = 0.1f;

    public float distanciaConoRepulsor = 1.0f;
    public float anguloConoRepulsor = 45.0f;
    public float velocidadRepulsion = 1.0f;

    void Update()
    {
        bool dispara = Input.GetButton("Fire1");

        if (dispara)
        {
            Collider[] enemigos = Physics.OverlapSphere(transform.position, distanciaConoRepulsor);
            foreach (var e in enemigos)
            {
                var eDummy = e.GetComponent<EnemigoDummy>();
                if (eDummy == null)
                {
                    continue;
                }

                var a = transform.forward;
                var b = (eDummy.transform.position - transform.position).normalized;
                // <a,b> = acos(cos(alfa)) = alfa
                var angulo = Mathf.Acos(Vector3.Dot(a, b)) * Mathf.Rad2Deg;
                if (angulo < anguloConoRepulsor)
                {
                    Debug.Log($"Enemigo {eDummy.name} angulo={angulo}");
                    //GameObject.Destroy(eDummy.gameObject);
                    var eRb = e.GetComponent<Rigidbody>();
                    eRb.AddExplosionForce(velocidadRepulsion, transform.position, distanciaConoRepulsor);
                    //eRb.velocity = b * velocidadRepulsion;
                }
            }
        }


        bool disparaMisil = Input.GetButton("Fire2");

        bool puedeDispararMisil = (Time.time - tiempoUltimoDisparoMisil) > tiempoCoolDownMisil;
        if (disparaMisil && puedeDispararMisil)
        {
            GameObject.Instantiate(prefabBala, origenArma.position, origenArma.rotation);
            tiempoUltimoDisparoMisil = Time.time;
            //Debug.Log("[ArmaPlayer] Disparando misil!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (float a = -45.0f; a < anguloConoRepulsor; a += 5.0f)
        {
            float radPlayer = transform.rotation.eulerAngles.y;
            Debug.Log($"Rot player {radPlayer}");
            float rad = Mathf.Deg2Rad * a - radPlayer * Mathf.Deg2Rad + 90.0f * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(rad), 0.0f, Mathf.Sin(rad));
            Gizmos.DrawLine(transform.position, transform.position + dir * distanciaConoRepulsor);
        }
    }
}
