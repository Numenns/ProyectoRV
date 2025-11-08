using System.Collections;
using UnityEngine;

public class Spawnfantasmas : MonoBehaviour
{
    public GameObject miky1;
    public GameObject miky2;
    public GameObject miky3;
    public GameObject gofy1;
    public GameObject gofy2;
    public GameObject gofy3;
    public GameObject oswald1;
    public GameObject oswald2;
    public GameObject oswald3;
    public GameObject miky1R;
    public GameObject miky2R;
    public GameObject miky3R;
    public GameObject gofy1R;
    public GameObject gofy2R;
    public GameObject gofy3R;
    public GameObject oswald1R;
    public GameObject oswald2R;
    public GameObject oswald3R;
    public GameObject mikyE;
    public GameObject gofyE;
    public GameObject mikyER;
    public GameObject gofyER;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instancia.iniciar)
        {
            StartCoroutine(Spawn());
            GameManager.Instancia.iniciar = false;
        }
    }
    
    IEnumerator Spawn()
    {
        Debug.Log("inicio");
        while(GameManager.Instancia.tiempoMax > GameManager.Instancia.tiempoMin || GameManager.Instancia.perderG == true || GameManager.Instancia.perderM == true|| GameManager.Instancia.perderO == true)
        {
            int x = Random.Range(1, 4);
            switch (x)
            {

                case 1:

                    int y = Random.Range(1, 4);
                    switch (y)
                    {
                        case 1:
                            miky1.SetActive(true);
                            miky1R.SetActive(true);
                            break;
                        case 2:
                            miky2.SetActive(true);
                            miky2R.SetActive(true);
                            break;
                        case 3:
                            miky3.SetActive(true);
                            miky3R.SetActive(true);
                            break;
                    }
                    break;
                case 2:
                    int u = Random.Range(1, 4);
                    switch (u)
                    {
                        case 1:
                            gofy1.SetActive(true);
                            gofy1R.SetActive(true);
                            break;
                        case 2:
                            gofy2.SetActive(true);
                            gofy2R.SetActive(true);
                            break;
                        case 3:
                            gofy3.SetActive(true);
                            gofy3R.SetActive(true);
                            break;
                    }
                    break;
                case 3:
                    int i = Random.Range(1, 4);
                    switch (i)
                    {
                        case 1:
                            oswald1.SetActive(true);
                            oswald1R.SetActive(true);
                            break;
                        case 2:
                            oswald2.SetActive(true);
                            oswald2R.SetActive(true);
                            break;
                        case 3:
                            oswald3.SetActive(true);
                            oswald3R.SetActive(true);
                            break;
                    }
                    break;
            }
            gofyE.SetActive(true);
            gofyER.SetActive(true);
            mikyE.SetActive(true);
            mikyER.SetActive(true);

            if (x == 1)
            {
                mikyER.SetActive(false);
                mikyE.SetActive(false);
            }
            else if (x == 2)
            {
                gofyE.SetActive(false);
                gofyER.SetActive(false);
            }
            yield return new WaitForSeconds(GameManager.Instancia.tiempoMax);
            
            miky1.SetActive(false);
            miky2.SetActive(false);
            miky3.SetActive(false);
            gofy1.SetActive(false);
            gofy2.SetActive(false);
            gofy3.SetActive(false);
            oswald1.SetActive(false);
            oswald2.SetActive(false);
            oswald3.SetActive(false);
            miky1R.SetActive(false);
            miky2R.SetActive(false);
            miky3R.SetActive(false);
            gofy1R.SetActive(false);
            gofy2R.SetActive(false);
            gofy3R.SetActive(false);
            oswald1R.SetActive(false);
            oswald2R.SetActive(false);
            oswald3R.SetActive(false);
            Debug.Log(GameManager.Instancia.tiempoMax);
        }
    }

}
