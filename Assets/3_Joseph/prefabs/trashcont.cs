using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ContadorDeTags : MonoBehaviour
{
    public Vector3 areaSize = new Vector3(1f, 1f, 1f);
    public enum TagSeleccion
    {
        TR1,
        TR2,
        TR3,
        TR4,
        TR5,
        TR6,
        TR7
    }

    [Header("Tag que quieres contar")]
    public TagSeleccion tagAContar = TagSeleccion.TR1;

    [Header("Cantidad máxima permitida")]
    public int maxObjetos = 5;

    [Header("Solo lectura - cuántos hay dentro")]
    [SerializeField] private int conteoActual = 0;

    [Header("Solo lectura - nombre medalla")]
    public String medalla;

    public int ConteoActual => conteoActual;
    public bool SobreLimite => conteoActual >= maxObjetos;
    private int conteoErroneo;
    public GameObject advertencia;
    

    string TagComoString()
    {
        
        return tagAContar.ToString();
    }

    private void Update()
    {
        if (GameManagers.Instancias.confirmando && conteoErroneo != 0)
        {
            advertencia.SetActive(true);
        }
        else
        {
            advertencia.SetActive(false);
        }
        if (conteoActual >= 2 && GameManagers.Instancias.victoria)
        {
            GameManagers.Instancias.medallas.Append(medalla);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagComoString()))
        {
            conteoActual++;
            GameManagers.Instancias.correctos++;

            Debug.Log($"Entró {other.name}. Conteo: {conteoActual}/{maxObjetos}");
        }
        else
        {
            conteoErroneo++;
            GameManagers.Instancias.incorrectos ++;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagComoString()))
        {
            conteoActual--;
            GameManagers.Instancias.correctos--;
            if (conteoActual < 0) conteoActual = 0;

           
            Debug.Log($"Salió {other.name}. Conteo: {conteoActual}/{maxObjetos}");
        }
        else
        {
            conteoErroneo--;
            GameManagers.Instancias.incorrectos --;
            if (conteoErroneo < 0) conteoErroneo = 0;
        }
    }
    
}
