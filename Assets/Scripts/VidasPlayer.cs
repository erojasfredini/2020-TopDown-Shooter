using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasPlayer : MonoBehaviour
{
    public AudioClip sonidoDanio;
    private AudioSource a;
    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("Enemigo"))
        {
            OnDanio();
        }
    }

    private void OnDanio()
    {
        Debug.Log("Golpe al player!");
        a.PlayOneShot(sonidoDanio);
    }
}
