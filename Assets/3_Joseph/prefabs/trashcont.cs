using UnityEngine;

public class ContadorDeTags : MonoBehaviour
{
    
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

    string TagComoString()
    {
        
        return tagAContar.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagComoString()))
        {
            conteoActual++;

           
            Debug.Log($"Entró {other.name}. Conteo: {conteoActual}/{maxObjetos}");
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
    }
}
