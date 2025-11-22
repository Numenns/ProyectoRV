using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    public static GameManagers Instancias;
    public int incorrectos;
    public int correctos;
    public bool confirmando;
    public bool victoria;
    public GameObject panelV;
    [SerializeField] private float espera;
    public List<string> medallas;
    private void Awake()
    {
        if (Instancias == null)
        {
            Instancias = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        medallas = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (victoria)
        {
            victoria = false;
            StartCoroutine(Fin());
        }
    }

    IEnumerator Fin()
    {
        yield return new WaitForSeconds(5f);
        panelV.SetActive(true);
        yield return new WaitForSeconds(espera);
        SceneManager.LoadScene("Menu");
    }
}
