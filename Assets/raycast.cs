using UnityEngine;


public class raycast : MonoBehaviour
{
    public float rayDistance = 20f;
    public LayerMask layer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer))
        {
            Debug.Log("Hit object: " + hit.collider.name);
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (hit.collider.CompareTag("fantasma"))
                {
                    hit.collider.gameObject.SetActive(false);
                }else if (hit.collider.CompareTag("fantasma2"))
                {
                    GameManager.Instancia.perderO = true;

                }
            }
            Debug.DrawLine(origin, hit.point, Color.red);
        }
    }
}
