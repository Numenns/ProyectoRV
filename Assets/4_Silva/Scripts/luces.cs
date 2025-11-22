using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] luces;
    public void ApagarLuces()
    {
        for (int i = 0; i < luces.Length; i++)
        {
            if (luces[i] != null && luces[i].enabled)
            {
                luces[i].enabled = false;
            }
        }

    }
    public void EncenderLuces()
    {
        for (int i = 0; i < luces.Length; i++)
        {
            luces[i].enabled = true;
        }

    }
}

