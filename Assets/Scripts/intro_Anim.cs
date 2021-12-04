using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_Anim : MonoBehaviour
{
    public float seconds_wait;
    public GameObject menu_obj, splash_obj, background_quad;

    void Start()
    {
        StartCoroutine(animation(seconds_wait));
    }

    IEnumerator animation(float seconds)
    {
        splash_obj.SetActive(true);
        menu_obj.SetActive(false);
        background_quad.SetActive(false);
        yield return new WaitForSeconds(seconds);
        splash_obj.SetActive(false);
        menu_obj.SetActive(true);
        background_quad.SetActive(true);
    }
}
