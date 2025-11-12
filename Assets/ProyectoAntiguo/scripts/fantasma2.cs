using System.Collections;
using UnityEngine;

public class fantasma2 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Perder());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Perder()
    {
        yield return new WaitForSeconds(GameManager.Instancia.tiempoMax);
        gameObject.SetActive(false);
    }
}
