using UnityEngine;

public class DistorsionarAudio : MonoBehaviour
{
    AudioSource audioSource;
    AudioDistortionFilter distorsion;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        distorsion = gameObject.AddComponent<AudioDistortionFilter>();

        // Asigna tu clip
        audioSource.clip = Resources.Load<AudioClip>("nombreDelAudio");
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        // Nivel de distorsión (0 a 1)
        distorsion.distortionLevel = 2f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
    }
}
