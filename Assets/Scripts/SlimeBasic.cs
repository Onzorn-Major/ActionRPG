using UnityEngine;
using UnityEngine.Rendering.UI;

public class SlimeBasic : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip slash1;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

}
