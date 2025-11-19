using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ContadorDeTags : MonoBehaviour
{
    public Vector3 areaSize = new Vector3(1f, 1f, 1f);
    public TextMeshPro countEr;
    public TextMeshPro countAc;
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

    public int ConteoActual => conteoActual;
    public bool SobreLimite => conteoActual >= maxObjetos;
    private int conteoErroneo;
    

    string TagComoString()
    {
        
        return tagAContar.ToString();
    }

    private void Update()
    {
        if (conteoErroneo == 0)
        {
            GameManagers.Instancias.incorrectos = true;
        }
        else
        {
            GameManagers.Instancias.incorrectos = false;
        }
        VaciarBasurero();
        countEr.text = conteoErroneo.ToString();
        countAc.text = conteoActual.ToString();
    }

    

    public void VaciarBasurero()
    {
        if(GameManagers.Instancias.incorrectos == false || GameManagers.Instancias.borrar)
        {
            Collider[] objetos = Physics.OverlapBox(transform.position, areaSize / 2f, Quaternion.identity);

            foreach (Collider obj in objetos)
            {
                Destroy(obj.gameObject);
            }
        }
        
    }

    // Para visualizar el área en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagComoString()))
        {
            conteoActual++;

           
            Debug.Log($"Entró {other.name}. Conteo: {conteoActual}/{maxObjetos}");
        }
        else
        {
            conteoErroneo++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagComoString()))
        {
            conteoActual--;
            if (conteoActual < 0) conteoActual = 0;

           
            Debug.Log($"Salió {other.name}. Conteo: {conteoActual}/{maxObjetos}");
        }
        else
        {
            conteoErroneo--;
            if (conteoErroneo < 0) conteoErroneo = 0;
        }
    }
    
}
