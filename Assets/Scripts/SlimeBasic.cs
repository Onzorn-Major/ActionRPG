using UnityEngine;

public class SlimeBasic : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip slash1;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            print("hit");
            audioSource.PlayOneShot(slash1);
        }

    }
}
