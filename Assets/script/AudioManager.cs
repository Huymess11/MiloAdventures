using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource source;
    [SerializeField] AudioSource SFXsource;
    public AudioClip Bg;
    public AudioClip Checkpoint;
    public AudioClip dash;
    public AudioClip Jump; 
    public AudioClip coin;
    public AudioClip dead;
    public AudioClip GameOver;
    public AudioClip Victory;

    void Start()
    {
        source.clip = Bg;
        source.loop = true;
        source.Play();
    }

    // Update is called once per frame
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
}
