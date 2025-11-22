using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [System.Serializable]
    public class NombreJugadorData
    {
        public string nombreJugador;
        public int correctos;
        public int incorrectos;
        public string[] medallas; // <- usa array para serializar con JsonUtility

        public NombreJugadorData(string nombre, int c, int i, string[] m)
        {
            nombreJugador = nombre;
            correctos = c;
            incorrectos = i;
            medallas = m;
        }
    }

    public static Scoreboard Instance;

    public string nombreJugadorActual;
    public int correctos;
    public int incorrectos;
    public List<string> medallasGuardadas = new List<string>();

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
        string[] medallasArray = GameManagers.Instancias != null
            ? GameManagers.Instancias.medallas.ToArray()
            : new string[0];

        NombreJugadorData data = new NombreJugadorData(
            nombreJugadorActual,
            GameManagers.Instancias != null ? GameManagers.Instancias.correctos : correctos,
            GameManagers.Instancias != null ? GameManagers.Instancias.incorrectos : incorrectos,
            medallasArray
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
            correctos = data.correctos;
            incorrectos = data.incorrectos;

            medallasGuardadas = new List<string>();
            if (data.medallas != null)
                medallasGuardadas.AddRange(data.medallas);
        }
        else
        {
            nombreJugadorActual = "";
            correctos = 0;
            incorrectos = 0;
            medallasGuardadas = new List<string>();
        }
    }
}
