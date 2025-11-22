using System.Collections;
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
