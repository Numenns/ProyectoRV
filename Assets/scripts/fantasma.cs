using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class fantasma : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Perder());
    }

    void Update()
    {
        
    }
    IEnumerator Perder()
    {
        yield return new WaitForSeconds(GameManager.Instancia.tiempoMax);
        if (gameObject.CompareTag("fantasma1")){
            GameManager.Instancia.perderM = true;
        }else if (gameObject.CompareTag("fantasma2"))
        {
            GameManager.Instancia.perderG = true;
        }

            gameObject.SetActive(false);
        
    }
}
