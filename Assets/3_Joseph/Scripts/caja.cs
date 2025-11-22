using System.Collections.Generic;
using UnityEngine;

public class CajaTriggerMasaYParent : MonoBehaviour
{
    
    private Dictionary<Rigidbody, float> masasOriginales = new Dictionary<Rigidbody, float>();

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
         
            if (!masasOriginales.ContainsKey(rb))
            {
                masasOriginales.Add(rb, rb.mass);
            }

           
            rb.mass = 0f;

            
            rb.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
         
            if (masasOriginales.ContainsKey(rb))
            {
                rb.mass = masasOriginales[rb];
                masasOriginales.Remove(rb);
            }

          
            rb.transform.SetParent(null);
        }
    }
}

