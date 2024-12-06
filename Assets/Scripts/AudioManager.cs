using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;

    public AudioClip MainMenu;

    private void Start()
    {
        musicSource.clip = MainMenu;
        musicSource.Play();
    }
}
