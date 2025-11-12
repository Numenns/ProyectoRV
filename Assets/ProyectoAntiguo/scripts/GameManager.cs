using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Boolean ganar;
    public Boolean perderM;
    public Boolean perderG;
    public Boolean perderO;
    public Boolean iniciar = false;
    public GameObject jumpscareM;
    public GameObject jumpscareG;
    public GameObject jumpscareO;
    public int x;
    public float tiempoMax;
    public float tiempoMin;
    public float tiempototal;
    public float tiempoE;

    void Start()
    {
        ganar = false;
        perderM = false;
        perderG = false;
        perderO = false;
        StartCoroutine(RestarTiempo());
    }

    
    void Update()
    {
        if (perderM)
        {
            jumpscareM.SetActive(true);
            StopAllCoroutines();
        }else if (perderG)
        {
            jumpscareG.SetActive(true);
            StopAllCoroutines();
        }
        else if (perderO)
        {
            jumpscareO.SetActive(true);
            StopAllCoroutines();
        }
        
    }
    public static GameManager Instancia;
    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RestarTiempo()
    {
        float tiempo = 0f;

        float inicio = GameManager.Instancia.tiempoMax;
        float fin = GameManager.Instancia.tiempoMin;
        float duracion = GameManager.Instancia.tiempototal;

        while (tiempo < duracion)
        {
            float valorActual = Mathf.Lerp(inicio, fin, tiempo / duracion);
            GameManager.Instancia.tiempoMax = valorActual;
            tiempo += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Valor final: " + fin);
    }


}
