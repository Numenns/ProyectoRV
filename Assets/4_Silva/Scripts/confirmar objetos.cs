using TMPro;
using UnityEngine;

public class confirmarobjetos : MonoBehaviour
{
    public Material pantalla;
    public TextMeshPro conteo;
    private bool pausar;
    public AudioSource aud;
    private Color X;
    void Start()
    {
        X = pantalla.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausar == false)
        {
            conteo.text = GameManagers.Instancias.correctos.ToString();
        }
    }
    public void confirmar()
    {
        if (GameManagers.Instancias.incorrectos !=0)
        {
            GameManagers.Instancias.confirmando = true;
            pausar = true;
            pantalla.color = Color.red;
            conteo.text = GameManagers.Instancias.incorrectos.ToString();
        }else if(GameManagers.Instancias.correctos < 10)
        {
            pantalla.color = Color.yellow;
        }
        else
        {
            pantalla.color = Color.green;
            GameManagers.Instancias.victoria = true;
        }
    }
    public void desactivar()
    {
        GameManagers.Instancias.confirmando = false;
        pausar = false;
        pantalla.color = X;
    }
}
