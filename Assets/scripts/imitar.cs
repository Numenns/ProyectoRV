using UnityEngine;

public class imitar : MonoBehaviour
{
    public Transform usuario;

    Vector3 posicionInicialImitador;
    Vector3 posicionInicialUsuario;

    void Start()
    {
        posicionInicialImitador = transform.position;
        posicionInicialUsuario = usuario.position;
    }

    void Update()
    {
        if (usuario == null) return;

        Vector3 deltaPos = usuario.position - posicionInicialUsuario;

        deltaPos.x *= -1;

        transform.position = posicionInicialImitador + deltaPos;
    }
}
