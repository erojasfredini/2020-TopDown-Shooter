using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionMarcador : MonoBehaviour
{
    private RectTransform r;
    public float frec = 1.0f;
    public float amplitud = 1.0f;
    void Start()
    {
        r = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (r == null)
        {
            return;
        }

        var w = 1.0f + Mathf.Sin(Time.deltaTime * frec) * amplitud;
        var h = 1.0f + Mathf.Sin(Time.deltaTime * frec) * amplitud;
        r.transform.localScale = new Vector3(w, h, 1.0f);
    }
}
