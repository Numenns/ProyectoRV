using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers Instancias;
    public bool incorrectos;
    public bool borrar;
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
        incorrectos = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
