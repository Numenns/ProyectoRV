using TMPro;
using UnityEngine;

public class confirmarobjetos : MonoBehaviour
{
    public Light luz1;
    public Light luz2;
    public Light luz3;
    public Light luz4;
    public Light luz5;
    public Light luz6;
    public Light luz7;
    public Light luz8;
    public AudioSource aud;
    public TextMeshPro count1;
    public TextMeshPro count2;
    public TextMeshPro count3;
    public TextMeshPro count4;
    public TextMeshPro count5;
    public TextMeshPro count6;
    public TextMeshPro count7;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void confirmar()
    {
        if (GameManagers.Instancias.incorrectos)
        {
            luz1.color = Color.red;
            luz2.color = Color.red;
            luz3.color = Color.red;
            luz4.color = Color.red;
            luz5.color = Color.red;
            luz6.color = Color.red;
            luz7.color = Color.red;
            luz8.color = Color.red;
            aud.Play();
            count1.enabled = true;
            count2.enabled = true;
            count3.enabled = true;
            count4.enabled = true;
            count5.enabled = true;
            count6.enabled = true;
            count7.enabled = true;
        }
    }
    public void desactivar()
    {
        luz1.color = Color.white;
        luz2.color = Color.white;
        luz3.color = Color.white;
        luz4.color = Color.white;
        luz5.color = Color.white;
        luz6.color = Color.white;
        luz7.color = Color.white;
        luz8.color = Color.white;
        aud.Stop();
        count1.enabled = false;
        count2.enabled = false;
        count3.enabled = false;
        count4.enabled = false;
        count5.enabled = false;
        count6.enabled = false;
        count7.enabled = false;
    }
}
