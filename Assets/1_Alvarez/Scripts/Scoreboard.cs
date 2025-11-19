using System.IO;
using System;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [System.Serializable]
    public class NombreJugadorData
    {
        public string nombreJugador;

        public int Residuos_comunes;
        public int Residuos_biologicos_infecciosos;
        public int Residuos_punzocortantes;
        public int Residuos_quimicos;
        public int Residuos_farmaceuticos;
        public int Residuos_radiactivos;
        public int Residuos_anatomicos;

        public NombreJugadorData(
            string nombre,
            int tr1,
            int tr2,
            int tr3,
            int tr4,
            int tr5,
            int tr6,
            int tr7
        )
        {
            nombreJugador = nombre;
            Residuos_comunes = tr1;
            Residuos_biologicos_infecciosos = tr2;
            Residuos_punzocortantes = tr3;
            Residuos_quimicos = tr4;
            Residuos_farmaceuticos = tr5;
            Residuos_radiactivos = tr6;
            Residuos_anatomicos = tr7;
        }
    }

    public static Scoreboard Instance;

    public string nombreJugadorActual;

    public int tr1;
    public int tr2;
    public int tr3;
    public int tr4;
    public int tr5;
    public int tr6;
    public int tr7;

    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        filePath = Application.persistentDataPath + "/nombreJugador.json";
        CargarDatos();
    }

    public void GuardarDatos()
    {
        NombreJugadorData data = new NombreJugadorData(
            nombreJugadorActual,
            tr1, tr2, tr3, tr4, tr5, tr6, tr7
        );

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public void CargarDatos()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            NombreJugadorData data = JsonUtility.FromJson<NombreJugadorData>(json);

            nombreJugadorActual = data.nombreJugador;

            tr1 = data.Residuos_comunes;
            tr2 = data.Residuos_biologicos_infecciosos;
            tr3 = data.Residuos_punzocortantes;
            tr4 = data.Residuos_quimicos;
            tr5 = data.Residuos_farmaceuticos;
            tr6 = data.Residuos_radiactivos;
            tr7 = data.Residuos_anatomicos;
        }
        else
        {
            nombreJugadorActual = "";
            tr1 = tr2 = tr3 = tr4 = tr5 = tr6 = tr7 = 0;
        }
    }
}
