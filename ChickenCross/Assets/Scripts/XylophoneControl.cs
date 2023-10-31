using UnityEngine;

public class XylophoneControl : MonoBehaviour
{
    public AudioClip xylophoneSound;
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            audioSource.PlayOneShot(xylophoneSound);
            hasPlayed = true;
        }
    }
}
