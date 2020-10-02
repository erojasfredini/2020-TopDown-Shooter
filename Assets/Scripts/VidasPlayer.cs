using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasPlayer : MonoBehaviour
{
    public AudioClip sonidoDanio;
    private AudioSource a;
    public float vidas = 100.0f;
    public Slider barraVidas;

    private void Update()
    {
        barraVidas.value = Mathf.Clamp(vidas, 0.0f, 100.0f);
    }

    void Start()
    {
        barraVidas.minValue = 0.0f;
        barraVidas.maxValue = 100.0f;
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
        vidas -= 1.0f;
        a.PlayOneShot(sonidoDanio);
    }
}
