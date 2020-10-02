using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPricipal : MonoBehaviour
{
    public GameObject panelOpciones;
    public GameObject panelPrincipal;

    public void OnPlay()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Toco Play");
    }

    public void OnOpciones()
    {
        panelOpciones.SetActive(true);
        panelPrincipal.SetActive(false);
        Debug.Log("Toco Opciones");
    }

    public void OnSalir()
    {
        Application.Quit();
        Debug.Log("Toco Salir");
    }

    public void OnOpcionesAtras()
    {
        panelOpciones.SetActive(false);
        panelPrincipal.SetActive(true);
        Debug.Log("Toco Atras");
    }
}
