using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelScores;
    public GameObject panelNombre;

    public void scores()
    {
        panelMenu.SetActive(false);
        panelScores.SetActive(true);
        panelNombre.SetActive(false);
    }

    public void menu()
    {
        panelMenu.SetActive(true);
        panelScores.SetActive(false);
        panelNombre.SetActive(false);
    }

    public void nombre()
    {
        panelMenu.SetActive(false);
        panelScores.SetActive(false);
        panelNombre.SetActive(true);
    }
}
